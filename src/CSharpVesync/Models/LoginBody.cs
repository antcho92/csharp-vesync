using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [ExcludeFromCodeCoverage]
    public class LoginBody : BaseRequestBody
    {
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "password")]
        public string Password { get; set; }
        [DataMember(Name = "devToken")]
        public string DevToken { get; set; } = string.Empty;
        [DataMember(Name = "userType")]
        public string UserType { get; set; } = "1";
    }
}
