using System.ServiceModel;
using System.ServiceModel.Web;

namespace ChannelFactoryOpt1RestClient
{
    [ServiceContract]
    public interface IServiceIAmInterestedIn
    {
        [WebGet(UriTemplate = "/users")]
        [OperationContract]
        People GetEverybody();

        [WebInvoke(UriTemplate = "/users", Method = "POST")]
        [OperationContract]
        Person AddAPerson(Person person);

        [WebGet(UriTemplate = "/users/{userId}")]
        [OperationContract]
        Person GetPerson(string userId);

        [WebInvoke(UriTemplate = "/users/{userId}", Method = "DELETE")]
        [OperationContract]
        void DeleteUser(string userId);

        [WebInvoke(UriTemplate = "/users/{userId}", Method = "PUT")]
        [OperationContract]
        Person UpdateUser(string userId, Person user);
    }
}