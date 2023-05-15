using System.ServiceModel;

namespace Example.CoreWcf.Client;

public class Program
{
    public static void Main(string[] args)
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
            else if (int.TryParse(input, out int n))
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
                   new EndpointAddress(@"http://localhost:8188/Service1.svc")))
        {
            string value = client.GetData(input);
            Console.WriteLine(value);
        }
    }
}
