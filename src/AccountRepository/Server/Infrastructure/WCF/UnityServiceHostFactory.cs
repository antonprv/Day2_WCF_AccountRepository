// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace Server.Infrastructure.WCF
{
  public class UnityServiceHostFactory : ServiceHostFactory
  {
    protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
    {
      Container.ContainerBuilder.Build(out Unity.IUnityContainer container);

      var host = new ServiceHost(serviceType, baseAddresses);
      host
        .Description
        .Behaviors
        .Add(new UnityServiceBehavior(container));

      return host;
    }
  }
}
