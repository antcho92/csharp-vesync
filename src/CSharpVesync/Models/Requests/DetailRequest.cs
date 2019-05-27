using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CSharpVesync.Models.Requests
{
    [DataContract]
    public class DetailRequest : RequestBody
    {
        [DataMember(Name = "mobileId")]
        public string MobileId { get; set; } = "1234567890123456";
    }
}
