using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class BaseResponse<T>
    {
        [DataMember(Name = "traceId")]
        public string TraceId { get; set; }
        [DataMember(Name = "code")]
        public string Code { get; set; }
        [DataMember(Name = "msg")]
        public string Msg { get; set; }
        [DataMember(Name = "result")]
        public T Result { get; set; }
    }
}
