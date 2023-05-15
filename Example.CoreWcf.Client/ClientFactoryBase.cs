using System.ServiceModel;
using System.ServiceModel.Channels;
using Example.CoreWcf.Contracts;

namespace Example.CoreWcf.Client;
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

public class ServiceClient : ClientBase<IService>, IService
{
    public ServiceClient() : base() { }

    public ServiceClient(string endpointConfigurationName)
        : base(endpointConfigurationName) { }

    public ServiceClient(string endpointconfigurationName, string remoteAddress)
        : base(endpointConfigurationName: endpointconfigurationName, remoteAddress: remoteAddress) { }

    public ServiceClient(Binding binding, EndpointAddress endPointAddress)
        : base(binding: binding, remoteAddress: endPointAddress) { }

    public string GetData(int value)
    {
        return Channel.GetData(value);
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        return Channel.GetDataUsingDataContract(composite);
    }
}

public class Service1ClientFactory : ClientFactoryBase<ServiceClient, IService>
{
    public Service1ClientFactory()
        : base(
            () => { return new ServiceClient(); },
            (e) => { return new ServiceClient(e); },
            (e, r) => { return new ServiceClient(e, r); },
            (b, e) => { return new ServiceClient(b, e); })
    {
    }
}