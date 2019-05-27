using System.Runtime.Serialization;

namespace CSharpVesync.Models.Requests
{
    [DataContract]
    public class BaseRequestBody
    {
        [DataMember(Name = "timeZone")]
        public string TimeZone { get; set; } = "America/Los_Angeles";
        [DataMember(Name = "acceptLanguage")]
        public string AcceptLanguage { get; set; } = "en";
        [DataMember(Name = "method")]
        public string Method { get; set; }
        [DataMember(Name = "appVersion")]
        public string AppVersion { get; set; } = "2.5.1";
        [DataMember(Name = "phoneBrand")]
        public string PhoneBrand { get; set; } = "SM N9005";
        [DataMember(Name = "phoneOS")]
        public string PhoneOS { get; set; } = "Android";
        [DataMember(Name = "traceId")]
        public string TraceId { get; set; } = "142312341234";
    }
}
