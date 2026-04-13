// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;

namespace Client.Models
{
  public static class Extensions
  {
    public static Server.User Convert(this User userClient) =>
      new Server.User()
      {
        Id = userClient.Id,
        FirstName = userClient.FirstName,
        FirstNameRu = userClient.FirstNameRu,
        LastName = userClient.LastName,
        LastNameRu = userClient.LastNameRu,
        Email = userClient.Email,
        Phone = userClient.Phone,
        BirthDate = userClient.BirthDate
      };

    public static User Convert(this Server.User userServer) =>
      new User(
        userServer.Id,
        userServer.FirstName,
        userServer.FirstNameRu,
        userServer.LastName,
        userServer.LastNameRu,
        userServer.Email,
        userServer.Phone,
        userServer.BirthDate
        );

    public static List<User> Convert(this Server.User[] userServerList)
    {
      var listClient = new List<User>();

      foreach (var item in userServerList)
        listClient.Add(Convert(item));

      return listClient;
    }

    public static Server.SearchQuery Convert(this SearchQuery queryClient) =>
      new Server.SearchQuery()
      {
        RawInput = queryClient.RawInput,
        Limit = queryClient.Limit
      };

    public static SearchQuery Convert(this Server.SearchQuery queryServer) =>
      new SearchQuery(queryServer.RawInput, queryServer.Limit);
  }
}
