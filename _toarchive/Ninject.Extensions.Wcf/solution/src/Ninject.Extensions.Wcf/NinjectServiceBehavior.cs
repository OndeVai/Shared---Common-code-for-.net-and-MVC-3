#region

using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    ///   Service behavior implementation for Ninject.
    /// </summary>
    public class NinjectServiceBehavior : IServiceBehavior
    {
        #region Implementation of IServiceBehavior

        /// <summary>
        ///   Provides the ability to inspect the service host and the service
        ///   description to confirm that the service can run successfully.
        /// </summary>
        /// <param name = "serviceDescription">
        ///   The service description.
        /// </param>
        /// <param name = "serviceHostBase">
        ///   The service host that is currently being constructed.
        /// </param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }

        /// <summary>
        ///   Provides the ability to pass custom data to binding elements to
        ///   support the contract implementation.
        /// </summary>
        /// <param name = "serviceDescription">
        ///   The service description of the service.
        /// </param>
        /// <param name = "serviceHostBase">
        ///   The host of the service.
        /// </param>
        /// <param name = "endpoints">
        ///   The service endpoints.
        /// </param>
        /// <param name = "bindingParameters">
        ///   Custom objects to which binding elements have access.
        /// </param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase,
                                         Collection<ServiceEndpoint> endpoints,
                                         BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>
        ///   Provides the ability to change run-time property values or insert
        ///   custom extension objects such as error handlers, message or
        ///   parameter interceptors, security extensions, and other custom
        ///   extension objects.
        /// </summary>
        /// <param name = "serviceDescription">
        ///   The service description.
        /// </param>
        /// <param name = "serviceHostBase">
        ///   The host that is currently being built.
        /// </param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var endpointDispatchers =
                serviceHostBase.ChannelDispatchers.OfType<ChannelDispatcher>()
                    .SelectMany(channelDispatcher => channelDispatcher.Endpoints);
            foreach (var endpointDispatcher in endpointDispatchers)
            {
                endpointDispatcher.DispatchRuntime.InstanceProvider =
                    new NinjectInstanceProvider(serviceDescription.ServiceType);
            }
        }

        #endregion
    }
}