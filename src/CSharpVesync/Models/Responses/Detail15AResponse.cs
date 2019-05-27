using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class Detail15AResponse
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "msg")]
        public string Msg { get; set; }
        [DataMember(Name = "deviceStatus")]
        public string DeviceStatus { get; set; }
        [DataMember(Name = "connectionStatus")]
        public string ConnectionStatus { get; set; }
        [DataMember(Name = "activeTime")]
        public int ActiveTime { get; set; }
        [DataMember(Name = "energy")]
        public double Energy { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "nightLightStatus")]
        public string NightLightStatus { get; set; }
        [DataMember(Name = "nightLightBrightness")]
        public int NightLightBrightness { get; set; }
        [DataMember(Name = "nightLightAutomode")]
        public string NightLightAutomode { get; set; }
        [DataMember(Name = "power")]
        public string Power { get; set; }
        [DataMember(Name = "voltage")]
        public string Voltage { get; set; }
    }

}