using Example.Wcf.Contracts;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Example.Wcf.Client
{
    public class Service1Client : ClientBase<IService1>, IService1
    {
        public Service1Client() : base() { }

        public Service1Client(string endpointConfigurationName)
            : base(endpointConfigurationName) { }

        public Service1Client(string endpointconfigurationName, string remoteAddress)
            : base(endpointConfigurationName: endpointconfigurationName, remoteAddress: remoteAddress) { }

        public Service1Client(Binding binding, EndpointAddress endPointAddress)
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
}
