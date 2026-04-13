// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Globalization;

namespace Server.Faults
{
  public static class FaultMessages
  {
    public static string GetAllFault()
    {
      if (IsRussian())
        return "Список пользователей пуст";

      return "No users found";
    }

    public static string GetByIdFault(int id)
    {
      if (IsRussian())
        return $"Пользователь с id {id} не найден";

      return $"Couldn't find user with id {id}";
    }

    public static string GetPageFault() => GetAllFault();

    public static string SearchFault(string query)
    {
      if (IsRussian())
        return $"По поиску {query} не нашлось результатов.";

      return $"No results found for the query {query}.";
    }

    public static string EditFault(Models.User user)
    {
      if (IsRussian())
        return $"Не удалось добавить пользователя: {user.ToString()}";

      return $"Couldn't add user: {user.ToString()}";
    }

    private static bool IsRussian() =>
      CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "ru";
  }
}
