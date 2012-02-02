#region

using System;
using System.ServiceModel.Web;

#endregion

namespace Ninject.Extensions.Wcf
{
    /// <summary>
    /// </summary>
    public class NinjectServiceHost : WebServiceHost
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "NinjectServiceHost" /> class.
        /// </summary>
        public NinjectServiceHost()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NinjectServiceHost" /> class.
        /// </summary>
        /// <param name = "serviceType">Type of the service.</param>
        public NinjectServiceHost(TypeCode serviceType)
            : base(serviceType)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NinjectServiceHost" /> class.
        /// </summary>
        /// <param name = "singletonInstance">The singleton instance.</param>
        public NinjectServiceHost(object singletonInstance)
            : base(singletonInstance)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "NinjectServiceHost" /> class.
        /// </summary>
        /// <param name = "serviceType">Type of the service.</param>
        /// <param name = "baseAddresses">The base addresses.</param>
        public NinjectServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        /// <summary>
        ///   Invoked during the transition of a communication object into the opening state.
        /// </summary>
        protected override void OnOpening()
        {
            Description.Behaviors.Add(new NinjectServiceBehavior());
            base.OnOpening();
        }
    }
}