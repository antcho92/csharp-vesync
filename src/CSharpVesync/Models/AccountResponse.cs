using System.Runtime.Serialization;

namespace CSharpVesync.Models
{
    [DataContract]
    public class AccountResponse
    {
        public string Token { get; set; }
        public string AccountId { get; set; }
        public string NickName { get; set; }
        public string AvatarIcon { get; set; }
        public int UserType { get; set; }
        public string AcceptLanguage { get; set; }
        public bool TermStatus { get; set; }
    }
}
