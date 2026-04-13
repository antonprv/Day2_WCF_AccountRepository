// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;
using System.Linq;

using Server.Models;
using Server.Repository;

namespace Server
{
  public class DatabaseService : IDatabaseService
  {
    private readonly IUserRepository _repository;

    public DatabaseService(IUserRepository repository) => _repository = repository;

    public int Add(User user) => _repository.Add(user);

    public bool Delete(int id) => _repository.Delete(id);

    public bool Edit(User user) => _repository.Edit(user);

    public List<User> GetAll()
    {
      var result = _repository.GetAll().ToList();
    }

    public User GetById(int id)
    {
      return _repository.GetById(id);
    }

    public List<User> GetPage(int pageIndex, int itemsInPage)
    {
      return _repository.GetPage(pageIndex, itemsInPage);
    }

    public List<User> Search(SearchQuery query)
    {
      var result = _repository.Search(query);


      return result;
    }
  }
}
