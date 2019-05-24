using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    public class RequestBody : BaseRequestBody
    {
        [DataMember(Name = "accountID")]
        public string AccountId { get; set; }
        [DataMember(Name = "token")]
        public string Token { get; set; }
    }
}
