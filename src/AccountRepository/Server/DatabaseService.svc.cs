// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

using Server.Faults;
using Server.Models;
using Server.Repository;
using Server.Validation.Messages;

namespace Server
{
  public class DatabaseService : IDatabaseService
  {
    private readonly IUserRepository _repository;

    public DatabaseService(IUserRepository repository) => _repository = repository;

    public int Add(User user) => _repository.Add(user);

    public bool Delete(int id) => _repository.Delete(id);

    public bool Edit(User user)
    {
      var validationResult = _repository.Edit(user);

      if (!validationResult.IsValid)
        ThrowWrongInput(
          nameof(Edit),
          FaultMessages.EditFault(user),
          ValidationMessages.Get(validationResult.Code)
          );

      return true;
    }

    public List<User> GetAll()
    {
      var result = _repository.GetAll().ToList();

      if (result == null)
        ThrowNotFound(
          nameof(GetAll),
          FaultMessages.GetAllFault()
          );

      return result;
    }

    public User GetById(int id)
    {
      var result = _repository.GetById(id);

      if (result == null)
        ThrowNotFound(
          nameof(GetById),
          FaultMessages.GetByIdFault(id)
          );

      return result;
    }

    public List<User> GetPage(int pageIndex, int itemsInPage)
    {
      var result = _repository.GetPage(pageIndex, itemsInPage);

      if (result == null)
        ThrowNotFound(
          nameof(GetPage),
          FaultMessages.GetPageFault()
          );

      return result;
    }

    public List<User> Search(SearchQuery query, int pageIndex)
    {
      var result = _repository.Search(query, pageIndex);

      if (result == null)
        ThrowNotFound(
          nameof(Search),
          FaultMessages.SearchFault(query.RawInput)
          );

      return result;
    }

    #region Helpers

    private static void ThrowWrongInput(string method, string message, string details)
    {
      var fault = new WrongInputFault(method, message, details);
      var reason = fault.GetReason();
      throw new FaultException<WrongInputFault>(fault, reason);
    }

    private static void ThrowNotFound(string method, string message)
    {
      var fault = new NotFoundFault(method, message);
      var reason = new FaultReason(fault.GetReason());
      throw new FaultException<NotFoundFault>(fault, reason);
    }

    #endregion
  }
}
