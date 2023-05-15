using CoreWCF;
using System;
using System.Runtime.Serialization;
using Example.CoreWcf.Contracts;

namespace Example.CoreWcf.Service
{

    public class Service : IService
    {
        private readonly ILogger logger;
        public Service(ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public string GetData(int value)
        {
            logger.LogInformation("GetData({0}) called", value);
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }

}
