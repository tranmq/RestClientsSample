using System;
using System.ServiceModel;

namespace ChannelFactoryOpt1RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IServiceIAmInterestedIn>("PrototypeRestClient");
            IServiceIAmInterestedIn serviceChannel = factory.CreateChannel();

            // a get
            var people = serviceChannel.GetEverybody();
            Console.WriteLine("List of everybody:");
            foreach (var x in people)
            {
                Console.Write("\t");
                Console.WriteLine(x);
            }

            var person = new Person { FirstName = "MQ", LastName = "Tran" };
            serviceChannel.AddAPerson(person);
            people = serviceChannel.GetEverybody();
            Console.WriteLine("New list of everybody:");
            foreach (var x in people)
            {
                Console.Write("\t");
                Console.WriteLine(x);
            }

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadLine();
        }
    }
}
