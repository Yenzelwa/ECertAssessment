using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace ECertAssessment.MVC.API.Service
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
