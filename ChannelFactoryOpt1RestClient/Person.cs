using System;
using System.Runtime.Serialization;

namespace ChannelFactoryOpt1RestClient
{
    [DataContract(Name = "user", Namespace = "")]
    public class Person
    {
        [DataMember(Name = "id", Order = 1)]
        public string UserId;

        [DataMember(Name = "firstname", Order = 2)]
        public string FirstName;

        [DataMember(Name = "lastname", Order = 3)]
        public string LastName;

        public override string ToString()
        {
            return String.Format("Id: {0}, Firstname: {1}, Lastname: {2}", UserId, FirstName, LastName);
        }
    }
}