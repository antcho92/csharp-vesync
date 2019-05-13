using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class AccountResponse
    {
        [DataMember(Name="tk")]
        public string Token { get; set; }
        [DataMember(Name="accountID")]
        public string AccountId { get; set; }
        [DataMember(Name="nickName")]
        public string NickName { get; set; }
        [DataMember(Name="avatarIcon")]
        public string AvatarIcon { get; set; }
        [DataMember(Name="userType")]
        public int UserType { get; set; }
        [DataMember(Name="acceptLanguage")]
        public string AcceptLanguage { get; set; }
        [DataMember(Name="termsStatus")]
        public bool TermStatus { get; set; }
    }
}
