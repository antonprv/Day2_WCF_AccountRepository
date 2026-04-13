// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.Generic;
using System.ServiceModel;

namespace Server
{
  [ServiceContract(Namespace = "http://account.repository/server")]
  public interface IDatabaseService
  {

    #region Create

    [OperationContract]
    int Add(Models.User user);

    #endregion

    #region Read

    [OperationContract]
    [FaultContract(typeof(Faults.NotFoundFault))]
    List<Models.User> GetAll();

    [OperationContract]
    [FaultContract(typeof(Faults.NotFoundFault))]
    List<Models.User> GetPage(int pageIndex, int itemsInPage);

    [OperationContract]
    [FaultContract(typeof(Faults.NotFoundFault))]
    Models.User GetById(int id);

    [OperationContract]
    [FaultContract(typeof(Faults.NotFoundFault))]
    List<Models.User> Search(Models.SearchQuery query);

    #endregion

    #region Update

    [OperationContract]
    [FaultContract(typeof(Faults.WrongInputFault))]
    bool Edit(Models.User user);

    #endregion

    #region Delete
    
    [OperationContract]
    bool Delete(int id);

    #endregion
  }
}
