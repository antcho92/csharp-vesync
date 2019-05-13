using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class Headers
    {
        [DataMember(Name="tk")]
        public string Token { get; set; }
        [DataMember(Name="accountid")]
        public string AccountId { get; set; }
    }
}
