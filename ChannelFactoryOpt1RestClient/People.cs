using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ChannelFactoryOpt1RestClient
{
    [CollectionDataContract(Name = "users", Namespace = "")]
    public class People : List<Person>
    {
    }
}