using System;
using System.ServiceModel;
using WrgPrototype.Contracts;

namespace ChannelFactoryOpt2RestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ChannelFactory<IUserService>("PrototypeRestClient");
            IUserService serviceChannel = factory.CreateChannel();

            var users = serviceChannel.GetAllUsers();

            Console.WriteLine("List of users");
            foreach (var user in users)
            {
                Console.Write("\t");
                Console.WriteLine("Id: {0}, Firstname: {1}, Lastname: {2}, Email: {3}", user.UserId, user.FirstName, user.LastName, user.Email);
            }

            var toBeAdded = new User { Email = "new@abc.com", FirstName = "John", LastName = "Doe", };
            var newUser = serviceChannel.AddUser(toBeAdded);

            users = serviceChannel.GetAllUsers();
            Console.WriteLine("New list of users");
            foreach (var user in users)
            {
                Console.Write("\t");
                Console.WriteLine("Id: {0}, Firstname: {1}, Lastname: {2}, Email: {3}", user.UserId, user.FirstName, user.LastName, user.Email);
            }

            Console.WriteLine("Press <ENTER> to continue");
            Console.ReadLine();
        }
    }
}
