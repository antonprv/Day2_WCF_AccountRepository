// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;

namespace Server.Repository
{
  public interface IUserRepository
  {
    #region Create

    int Add(Models.User user);

    #endregion

    #region Read

    List<Models.User> GetAll();
    List<Models.User> GetPage(int pageIndex, int itemsInPage);
    Models.User GetById(int id);
    List<Models.User> Search(Models.SearchQuery query);

    #endregion

    #region Edit

    Validation.ValidationResult Edit (Models.User user);

    #endregion

    #region Delete

    bool Delete(int id);

    #endregion
  }
}
