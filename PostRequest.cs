using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace func_swagger_test
{
    [JsonObject]
    [DataContract]
    public class PostRequest
    {

        public string Stuff { get; set; }
        public string OtherStuff { get; set; }

    }
}