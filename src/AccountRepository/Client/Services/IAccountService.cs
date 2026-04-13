// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;

namespace Client.Services
{
  public interface IAccountService
  {
    int Add(Models.User user);

    List<Models.User> GetAll();

    List<Models.User> GetPage(int pageIndex, int itemsInPage);

    Models.User GetById(int id);

    List<Models.User> Search(Models.SearchQuery query);

    bool Edit(Models.User user);

    bool Delete(int id);

  }
}
