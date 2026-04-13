// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

using Unity;

namespace Server.Infrastructure.WCF
{
  public class UnityInstanceProvider : IInstanceProvider
  {
    private readonly IUnityContainer _container;
    private readonly Type _serviceType;

    public UnityInstanceProvider(IUnityContainer container, Type serviceType)
    {
      _container = container;
      _serviceType = serviceType;
    }

    public object GetInstance(InstanceContext instanceContext) =>
      GetInstance(instanceContext, null);

    public object GetInstance(InstanceContext instanceContext, Message message) =>
      _container.Resolve(_serviceType);


    public void ReleaseInstance(InstanceContext instanceContext, object instance) =>
      (instance as IDisposable)?.Dispose();
  }
}
