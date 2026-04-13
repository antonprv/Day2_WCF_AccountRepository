// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Configuration;

using Server.Repository;

using Unity;
using Unity.Lifetime;

namespace Server.Infrastructure.Container
{
  public static class ContainerBuilder
  {
    public static void Build(out IUnityContainer container)
    {
      container = new UnityContainer();
      BuildDependencies(container);
    }

    private static void BuildDependencies(IUnityContainer container)
    {
      BindConnectionString(container);
      BindUserRepository(container);
    }

    #region String Bindings

    private static void BindConnectionString(IUnityContainer container)
    {
      var connectionString = ConfigurationManager
        .ConnectionStrings["UsersDb"]
        .ConnectionString;

      container.RegisterInstance<string>(
        ContainerKeys.ConnectionString,
        connectionString
        );
    }

    #endregion

    #region Interface Bindings

    private static void BindUserRepository(IUnityContainer container)
    {
      var connectionString = container.Resolve<string>(ContainerKeys.ConnectionString);

      container.RegisterType<IUserRepository, UserRepository>(
        new TransientLifetimeManager(),
        new Unity.Injection.InjectionConstructor(connectionString)
        );
    }

    #endregion
  }
}
