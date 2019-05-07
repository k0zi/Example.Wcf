using Example.Wcf.Contracts;

namespace Example.Wcf.Client
{
    public class Service1ClientFactory : ClientFactoryBase<Service1Client, IService1>
    {
        public Service1ClientFactory() 
            : base(
                  ()=> { return new Service1Client(); }, 
                  (e) => { return new Service1Client(e); },
                  (e, r) => { return new Service1Client(e, r); },
                  (b, e) => { return new Service1Client(b, e); })
        {
        }
    }
}
