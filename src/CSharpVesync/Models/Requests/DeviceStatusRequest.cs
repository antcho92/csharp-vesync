using System.Runtime.Serialization;

namespace CSharpVesync.Models.Requests
{
    [DataContract]
    public class DeviceStatusRequest : RequestBody
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }
    }
}
