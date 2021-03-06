using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class Detail7AResponse
    {
        [DataMember(Name = "deviceStatus")]
        public string DeviceStatus { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "activeTime")]
        public int ActiveTime { get; set; }
        [DataMember(Name = "energy")]
        public double Energy { get; set; }
        [DataMember(Name = "power")]
        public string Power { get; set; }
        [DataMember(Name = "voltage")]
        public string Voltage { get; set; }
    }
}
