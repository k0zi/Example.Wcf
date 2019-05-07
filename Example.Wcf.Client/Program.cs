using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Example.Wcf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            var factory = new Service1ClientFactory();
            do
            {
                string input = Console.ReadLine();
                if (input.Equals("e", StringComparison.InvariantCultureIgnoreCase))
                {
                    exit = true;
                }
                else if(int.TryParse(input, out int n))
                {
                    int inputNumber = int.Parse(input);
                    CallService(inputNumber, factory);
                }

            } while (!exit);
            Console.ReadKey();
        }

        private static void CallService(int input, Service1ClientFactory factory)
        {
            using (var client = factory.Create(
                new BasicHttpBinding(),
                new EndpointAddress(@"http://localhost:63553/Service1.svc")))
            {
                string value = client.GetData(input);
                Console.WriteLine(value);
            }
        }
    }
}
