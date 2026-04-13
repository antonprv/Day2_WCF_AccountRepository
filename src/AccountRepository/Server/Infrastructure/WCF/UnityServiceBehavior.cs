// Created by Anton Piruev in 2026. 
// Any direct commercial use of derivative work is strictly prohibited.

using System.Collections.ObjectModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

using Unity;

namespace Server.Infrastructure.WCF
{
  public class UnityServiceBehavior : IServiceBehavior
  {
    private readonly IUnityContainer _unityContainer;

    public UnityServiceBehavior(IUnityContainer unityContainer) =>
      _unityContainer = unityContainer;

    public void ApplyDispatchBehavior(ServiceDescription desc, ServiceHostBase host)
    {
      foreach (ChannelDispatcherBase cdb in host.ChannelDispatchers)
      {
        var cd = cdb as ChannelDispatcher;
        if (cd == null) continue;

        foreach (var endpoint in cd.Endpoints)
        {
          endpoint
            .DispatchRuntime
            .InstanceProvider = new UnityInstanceProvider(
              _unityContainer,
              desc.ServiceType
              );
        }
      }
    }


    #region Placeholders (interface)

    public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }

    #endregion
  }
}
