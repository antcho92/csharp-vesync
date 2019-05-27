using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    public class EnergyResponse15A : EnergyResponse7A
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        [DataMember(Name = "msg")]
        public object Message { get; set; }
    }
}