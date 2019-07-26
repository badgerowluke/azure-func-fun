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
    [JsonObject]
    [DataContract]
    public class PostResponse
    {
        [DataMember]
        [MinLength(5)]
        [MaxLength(35)]
        public string MoreStuff { get; set; }
        public string AdditionalStuff { get; set;}
    }
}