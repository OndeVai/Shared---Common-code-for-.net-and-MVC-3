#region

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    /// </summary>
    public class NinjectInstanceProvider : IInstanceProvider
    {
        private readonly Type _serviceType;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NinjectInstanceProvider" /> class.
        /// </summary>
        /// <param name = "serviceType">Type of the service.</param>
        public NinjectInstanceProvider(Type serviceType)
        {
            _serviceType = serviceType;
        }

        #region Implementation of IInstanceProvider

        /// <summary>
        ///   Returns a service object given the specified <see cref = "T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>
        ///   A user-defined service object.
        /// </returns>
        /// <param name = "instanceContext">
        ///   The current <see cref = "T:System.ServiceModel.InstanceContext" />
        ///   object.
        /// </param>
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext, null);
        }

        /// <summary>
        ///   Returns a service object given the specified <see cref = "T:System.ServiceModel.InstanceContext" /> object.
        /// </summary>
        /// <returns>
        ///   The service object.
        /// </returns>
        /// <param name = "instanceContext">
        ///   The current <see cref = "T:System.ServiceModel.InstanceContext" />
        ///   object.
        /// </param>
        /// <param name = "message">
        ///   The message that triggered the creation of a service object.
        /// </param>
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return KernelContainer.Kernel.Get(_serviceType);
        }

        /// <summary>
        ///   Called when an <see cref = "T:System.ServiceModel.InstanceContext" />
        ///   object recycles a service object.
        /// </summary>
        /// <param name = "instanceContext">
        ///   The service's instance context.
        /// </param>
        /// <param name = "instance">
        ///   The service object to be recycled.
        /// </param>
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
        }

        #endregion
    }
}