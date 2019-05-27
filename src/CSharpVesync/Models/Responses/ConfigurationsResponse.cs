using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class ConfigurationsResponse
    {
        [DataMember(Name = "deviceName")]
        public string DeviceName { get; set; }
        [DataMember(Name = "deviceImg")]
        public string DeviceImg { get; set; }
        [DataMember(Name = "allowNotify")]
        public string AllowNotify { get; set; }
        [DataMember(Name = "currentFirmVersion")]
        public string CurrentFirmVersion { get; set; }
        [DataMember(Name = "latestFirmVersion")]
        public string LatestFirmVersion { get; set; }
        [DataMember(Name = "ownerShip")]
        public bool OwnerShip { get; set; }
        [DataMember(Name = "energySavingStatus")]
        public string EnergySavingStatus { get; set; }
        [DataMember(Name = "powerProtectionStatus")]
        public string PowerProtectionStatus { get; set; }
        [DataMember(Name = "maxCost")]
        public int MaxCost { get; set; }
        [DataMember(Name = "costPerKWH")]
        public double CostPerKWH { get; set; }
        [DataMember(Name = "threshHold")]
        public int ThreshHold { get; set; }
        [DataMember(Name = "maxPower")]
        public int MaxPower { get; set; }
        [DataMember(Name = "saleschannel")]
        public string Saleschannel { get; set; }
        [DataMember(Name = "isUpgrading")]
        public bool IsUpgrading { get; set; }
    }
}
