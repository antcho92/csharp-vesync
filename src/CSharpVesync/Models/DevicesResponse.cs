using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class DevicesResponse
    {
        [DataMember(Name = "deviceName")]
        public string DeviceName { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "cid")]
        public string Cid { get; set; }
        [DataMember(Name = "deviceStatus")]
        public string DeviceStatus { get; set; }
        [DataMember(Name = "connectionType")]
        public int ConnectionType { get; set; }
        [DataMember(Name = "connectionStatus")]
        public string ConnectionStatus { get; set; }
        [DataMember(Name = "deviceType")]
        public bool DeviceType { get; set; }
        [DataMember(Name = "model")]
        public bool Model { get; set; }
        [DataMember(Name = "currentFirmVersion")]
        public bool CurrentFirmwareVersion { get; set; }
    }
}
