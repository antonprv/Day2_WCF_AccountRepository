// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;

using Client.Models;
using Client.Server;

namespace Client.Services
{
  public class WcfAccountService : IAccountService
  {
    private readonly DatabaseServiceClient _dbService;

    public WcfAccountService(DatabaseServiceClient dbClient) =>
      _dbService = dbClient;

    public int Add(Models.User user) =>
      _dbService.Add(user.Convert());

    public bool Delete(int id) =>
      _dbService.Delete(id);

    public bool Edit(Models.User user) =>
      _dbService.Edit(user.Convert());

    public List<Models.User> GetAll()
      => _dbService.GetAll().Convert();

    public Models.User GetById(int id) =>
      _dbService.GetById(id).Convert();

    public List<Models.User> GetPage(int pageIndex, int itemsInPage) =>
      _dbService.GetPage(pageIndex, itemsInPage).Convert();

    public List<Models.User> Search(Models.SearchQuery query) =>
      _dbService.Search(query.Convert()).Convert();
  }
}
