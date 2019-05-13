using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class DetailResponse
    {
        [DataMember(Name = "deviceStatus")]
        public string DeviceName { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "activeTime")]
        public string ActiveTime { get; set; }
        [DataMember(Name = "energy")]
        public string Energy { get; set; }
        [DataMember(Name = "power")]
        public string Power { get; set; }
        [DataMember(Name = "voltage")]
        public bool Voltage { get; set; }
    }
}
