using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    public class Headers
    {
        [JsonProperty("tk")]
        public string Token { get; set; }
        [JsonProperty("accountID")]
        public string AccountId { get; set; }
    }
}
