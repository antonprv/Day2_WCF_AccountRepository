// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using Client.Forms;
using Client.Server;
using Client.Services;

using Unity;
using Unity.Lifetime;

namespace Client.Infrastructure
{
  public static class UnityContainerBuilder
  {
    public static IUnityContainer Build()
    {
      var container = new UnityContainer();

      BindDependencies(container);

      return container;
    }

    private static void BindDependencies(IUnityContainer container)
    {
      BindWcfService(container);
      BindAccountService(container);
      BindUserProvider(container);
      BindMainForm(container);
    }

    private static void BindWcfService(IUnityContainer container) =>
      container
      .RegisterInstance<DatabaseServiceClient>(
        ContainerKeys.DbService,
        new DatabaseServiceClient());

    private static void BindAccountService(IUnityContainer container)
    {
      var dbService = container.Resolve<DatabaseServiceClient>(ContainerKeys.DbService);

      container
      .RegisterType<IAccountService, WcfAccountService>(
        new TransientLifetimeManager(),
        new Unity.Injection.InjectionConstructor(dbService));
    }

    private static void BindUserProvider(IUnityContainer container) =>
      container
      .RegisterType<IUserProvider, UserEditForm>(
        new TransientLifetimeManager());

    private static void BindMainForm(IUnityContainer container) =>
      container.RegisterType<Forms.MainForm>();
  }
}
