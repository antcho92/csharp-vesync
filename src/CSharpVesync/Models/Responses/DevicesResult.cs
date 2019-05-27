using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class DevicesResult
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }
        [DataMember(Name = "pageNo")]
        public int PageNo { get; set; }
        [DataMember(Name = "pageSize")]
        public int pageSize { get; set; }
        [DataMember(Name = "list")]
        public Device[] List { get; set; }
    }

    [DataContract]
    public class Device
    {
        [DataMember(Name = "deviceName")]
        public string DeviceName { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "cid")]
        public string Cid { get; set; }
        [DataMember(Name = "deviceStatus")]
        public string DeviceStatus { get; set; }
        [DataMember(Name = "connectionStatus")]
        public string ConnectionStatus { get; set; }
        [DataMember(Name = "connectionType")]
        public string ConnectionType { get; set; }
        [DataMember(Name = "deviceType")]
        public string DeviceType { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "uuid")]
        public string Uuid { get; set; }
        [DataMember(Name = "configModule")]
        public string ConfigModule { get; set; }
        [DataMember(Name = "macID")]
        public string MacID { get; set; }
        [DataMember(Name = "mode")]
        public string Mode { get; set; }
        [DataMember(Name = "speed")]
        public string Speed { get; set; }
        [DataMember(Name = "extension")]
        public string Extension { get; set; }
        [DataMember(Name = "currentFirmVersion")]
        public string CurrentFirmwareVersion { get; set; }
    }
}