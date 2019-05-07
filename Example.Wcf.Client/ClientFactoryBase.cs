using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Example.Wcf.Client
{
    public abstract class ClientFactoryBase<TService, TContract> 
        where TService : ClientBase<TContract>, TContract
        where TContract : class
    {
        protected readonly Func<TService> defaultFactory;
        protected readonly Func<string, TService> withEndpointConfigurationName;
        protected readonly Func<string, string, TService> withEndpointConfigurationNameAndRemoteAddress;
        protected readonly Func<Binding, EndpointAddress, TService> withBindingAndEndpointAddress;

        protected ClientFactoryBase(
            Func<TService> defaultFactory,
            Func<string, TService> withEndpointConfigurationName,
            Func<string, string, TService> withEndpointConfigurationNameAndRemoteAddress,
            Func<Binding, EndpointAddress, TService> withBindingAndEndpointAddress)
        {
            this.defaultFactory = defaultFactory;
            this.withEndpointConfigurationName = withEndpointConfigurationName;
            this.withEndpointConfigurationNameAndRemoteAddress = withEndpointConfigurationNameAndRemoteAddress;
            this.withBindingAndEndpointAddress = withBindingAndEndpointAddress;
        }

        public TService Create()
        {
            return defaultFactory();
        }

        public TService Create(string endpointConfigurationName)
        {
            return withEndpointConfigurationName(endpointConfigurationName);
        }

        public TService Create(string endpointconfigurationName, string remoteAddress)
        {
            return withEndpointConfigurationNameAndRemoteAddress(endpointconfigurationName, remoteAddress);
        }

        public TService Create(Binding binding, EndpointAddress endPointAddress)
        {
            return withBindingAndEndpointAddress(binding, endPointAddress);
        }
    }
}
