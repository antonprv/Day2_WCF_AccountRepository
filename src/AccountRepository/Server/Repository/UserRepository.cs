// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Data.Sqlite;

namespace Server.Repository
{
  public class UserRepository : IUserRepository
  {
    private const string _usersTable = "valtheria_people";
    private readonly string _ftsTable = "valtheria_people_fts";

    private readonly string _connectionString;

    public UserRepository(string connectionString) =>
      _connectionString = connectionString;

    #region Create

    public int Add(Models.User user)
    {
      int lastInsertRow = 0;

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"INSERT INTO {_usersTable} (
          firstName, firstName_ru, lastName, lastName_ru, email, phone, birthDate)
          VALUES (@firstName, @firstName_ru, @lastName, @lastName_ru, @email, @phone, @birthDate );
          SELECT last_insert_rowid();";

        using (var cmd = new SqliteCommand(command, connection))
        {
          cmd.Parameters.AddWithValue("@firstName", user.FirstName);
          cmd.Parameters.AddWithValue("@firstName_ru", user.FirstNameRu);
          cmd.Parameters.AddWithValue("@lastName", user.LastName);
          cmd.Parameters.AddWithValue("@lastName_ru", user.LastNameRu);
          cmd.Parameters.AddWithValue("@email", user.Email);
          cmd.Parameters.AddWithValue("@phone", user.Phone);
          cmd.Parameters.AddWithValue("@birthDate", user.BirthDate.ToString("yyyy-MM-dd"));

          lastInsertRow = Convert.ToInt32(cmd.ExecuteScalar());
        }
      }

      return lastInsertRow;
    }

    #endregion

    #region Read

    public List<Models.User> GetAll()
    {
      var users = new List<Models.User>();

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"SELECT * FROM {_usersTable}";

        using (var cmd = new SqliteCommand(command, connection))
        {
          using (var reader = cmd.ExecuteReader())
            while (reader.Read())
              users.Add(MapReader(reader));

          if (users.Count == 0)
            return null;
        }
      }

      return users;
    }

    public Models.User GetById(int id)
    {
      var user = new Models.User();

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"SELECT * FROM {_usersTable} WHERE id = @id";

        using (var cmd = new SqliteCommand(command, connection))
        {
          cmd.Parameters.AddWithValue("@id", id);

          using (var reader = cmd.ExecuteReader())
          {
            if (reader.Read())
              user = MapReader(reader);

            if (user == null || user.IsEmpty())
              return null;
          }
        }
      }

      return user;
    }

    public List<Models.User> GetPage(int pageIndex, int itemsInPage)
    {
      var users = new List<Models.User>();

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"SELECT * FROM {_usersTable} LIMIT @limit OFFSET @offset";

        using (var cmd = new SqliteCommand(command, connection))
        {
          cmd.Parameters.AddWithValue("@limit", itemsInPage);
          cmd.Parameters.AddWithValue("@offset", pageIndex * itemsInPage);

          using (var reader = cmd.ExecuteReader())
            while (reader.Read())
              users.Add(MapReader(reader));

          if (users.Count == 0)
            return null;
        }
      }

      return users;
    }

    #region Search

    public List<Models.User> Search(Models.SearchQuery query)
    {
      var ftsQuery = Validation.SearchQueryParser.ParseFts(query.RawInput);
      if (ftsQuery == null)
        return new List<Models.User>();

      // bm25 order for relevancy filter
      var sql = $@"
        SELECT p.*
        FROM  {_usersTable} p
        JOIN  {_ftsTable} f ON f.rowid = p.id
        WHERE {_ftsTable} MATCH @ftsQuery
        ORDER BY bm25({_ftsTable})
        LIMIT @limit";

      var result = new List<Models.User>();

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();
        using (var cmd = new SqliteCommand(sql, connection))
        {
          cmd.Parameters.AddWithValue("@ftsQuery", ftsQuery);
          cmd.Parameters.AddWithValue("@limit", query.Limit);

          using (var reader = cmd.ExecuteReader())
            while (reader.Read())
              result.Add(MapReader(reader));

          if (result.Count == 0)
            return Search_Slow(query);
        }
      }

      return result;
    }

    // Legacy search with %Like%
    public List<Models.User> Search_Slow(Models.SearchQuery query)
    {
      var tokens = Validation.SearchQueryParser.Parse(query.RawInput);

      // Пустой запрос — возвращаем всё
      if (tokens.Length == 0)
        return GetAll().ToList();

      // Строим SQL динамически под каждый токен
      // Логика: каждый токен должен совпасть хотя бы с одним полем
      // Несколько токенов соединяются через AND —
      // то есть "john gmail" найдёт только тех, у кого И "john" И "gmail" где-то есть

      var conditions = new List<string>();
      var parameters = new List<SqliteParameter>();

      for (int i = 0; i < tokens.Length; i++)
      {
        // Один токен проверяется по всем полям через OR
        conditions.Add($@"(
            LOWER(FirstName)    LIKE @t{i} OR
            FirstName_RU        LIKE @t{i} OR
            LOWER(LastName)     LIKE @t{i} OR
            LastName_RU         LIKE @t{i} OR
            LOWER(Email)        LIKE @t{i} OR
            Phone               LIKE @t{i} OR
            BirthDate           LIKE @t{i}
        )");

        // % с обеих сторон — совпадение в любом месте строки
        parameters.Add(new SqliteParameter($"@t{i}", $"%{tokens[i]}%"));
      }

      var sql = $@"
        SELECT * FROM {_usersTable}
        WHERE {string.Join(" AND ", conditions)}
        LIMIT @limit";

      parameters.Add(new SqliteParameter("@limit", query.Limit));

      var result = new List<Models.User>();

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();
        using (var cmd = new SqliteCommand(sql, connection))
        {
          cmd.Parameters.AddRange(parameters.ToArray());
          using (var reader = cmd.ExecuteReader())
            while (reader.Read())
              result.Add(MapReader(reader));

          if (result.Count == 0)
            return null;
        }
      }

      return result;
    }

    #endregion

    #endregion

    #region Update

    public Validation.ValidationResult Edit(Models.User user)
    {
      int rowsChanged = 0;

      var validationResult = user.Validate();

      if (!validationResult.IsValid)
        return Validation.ValidationResult.Fail(validationResult.Code);

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"UPDATE {_usersTable}
          SET firstName   = @firstName,
            firstName_ru  = @firstName_ru,
            lastName      = @lastName,
            lastName_ru   = @lastName_ru,
            email         = @email,
            phone         = @phone,
            birthDate     = @birthDate
          WHERE id        = @id;

          SELECT changes();";

        using (var cmd = new SqliteCommand(command, connection))
        {
          cmd.Parameters.AddWithValue("@firstName", user.FirstName);
          cmd.Parameters.AddWithValue("@firstName_ru", user.FirstNameRu);
          cmd.Parameters.AddWithValue("@lastName", user.LastName);
          cmd.Parameters.AddWithValue("@lastName_ru", user.LastNameRu);
          cmd.Parameters.AddWithValue("@email", user.Email);
          cmd.Parameters.AddWithValue("@phone", user.Phone);
          cmd.Parameters.AddWithValue("@birthDate", user.BirthDate);

          cmd.Parameters.AddWithValue("@id", user.Id);

          rowsChanged = Convert.ToInt32(cmd.ExecuteScalar());
        }
      }

      return rowsChanged != 0 ?
        Validation.ValidationResult.Ok() :
        Validation.ValidationResult.Fail(Validation.Messages.ValidationCode.DbError);
    }

    #endregion

    #region Delete

    public bool Delete(int id)
    {
      int rowsChanged = 0;

      using (var connection = new SqliteConnection(_connectionString))
      {
        connection.Open();

        var command = $@"DELETE FROM {_usersTable}
          WHERE id = @id;

          SELECT changes();";

        using (var cmd = new SqliteCommand(command, connection))
        {
          cmd.Parameters.AddWithValue("@id", id);

          rowsChanged = Convert.ToInt32(cmd.ExecuteScalar());
        }
      }

      return rowsChanged != 0;
    }

    #endregion

    #region Helpers

    private Models.User MapReader(SqliteDataReader r) =>
      new Models.User(
        Convert.ToInt32(r["id"]),
        r["firstName"].ToString(),
        r["firstName_ru"].ToString(),
        r["lastName"].ToString(),
        r["lastName_ru"].ToString(),
        r["email"].ToString(),
        r["phone"].ToString(),
        DateTime.Parse(r["birthDate"].ToString())
      );

    #endregion
  }
}
