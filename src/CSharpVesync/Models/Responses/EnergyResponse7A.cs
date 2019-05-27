using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class EnergyResponse7A
    {
        [DataMember(Name = "energyConsumptionOfToday")]
        public double EnergyConsumptionOfToday { get; set; }
        [DataMember(Name = "costPerKWH")]
        public double CostPerKWH { get; set; }
        [DataMember(Name = "maxEnergy")]
        public double MaxEnergy { get; set; }
        [DataMember(Name = "data")]
        public double[] Data { get; set; }
        [DataMember(Name = "totalEnergy")]
        public double TotalEnergy { get; set; }
    }
}