using System.Runtime.Serialization;

namespace CSharpVesync.Models.Responses
{
    [DataContract]
    public class LoginResult
    {
        [DataMember(Name = "token")]
        public string Token { get; set; }
        [DataMember(Name = "accountID")]
        public string AccountId { get; set; }
        [DataMember(Name = "userType")]
        public string UserType { get; set; }
        [DataMember(Name = "avatarIcon")]
        public string AvatarIcon { get; set; }
        [DataMember(Name = "nickName")]
        public string NickName { get; set; }
        [DataMember(Name = "gender")]
        public string Gender { get; set; }
        [DataMember(Name = "birthday")]
        public string Birthday { get; set; }
        [DataMember(Name = "mailConfirmation")]
        public bool MailConfirmation { get; set; }
        [DataMember(Name = "acceptLanguage")]
        public string AacceptLanguage { get; set; }
        [DataMember(Name = "gdprStatus")]
        public bool GdprStatus { get; set; }
        [DataMember(Name = "heightCm")]
        public double HeightCm { get; set; }
        [DataMember(Name = "heightFt")]
        public double HeightFt { get; set; }
        [DataMember(Name = "weightTargetKg")]
        public double WeightTargetKg { get; set; }
        [DataMember(Name = "weightTargetLb")]
        public double WeightTargetLb { get; set; }
        [DataMember(Name = "weightTargetSt")]
        public double WeightTargetSt { get; set; }
        [DataMember(Name = "weightUnit")]
        public string WeightUnit { get; set; }
        [DataMember(Name = "heightUnit")]
        public string HeightUnit { get; set; }
        [DataMember(Name = "targetBfr")]
        public double TargetBfr { get; set; }
        [DataMember(Name = "displayFlag")]
        public object[] DisplayFlag { get; set; }
        [DataMember(Name = "real_weight_kg")]
        public double RealWeightKg { get; set; }
        [DataMember(Name = "real_weight_lb")]
        public double RealWeightLb { get; set; }
        [DataMember(Name = "real_weight_unit")]
        public string RealWeightUnit { get; set; }
        [DataMember(Name = "heart_rate_zones")]
        public double HeartRateZones { get; set; }
        [DataMember(Name = "run_step_long_cm")]
        public double RunStepLongCm { get; set; }
        [DataMember(Name = "walk_step_long_cm")]
        public double WalkStepLongCm { get; set; }
        [DataMember(Name = "step_target")]
        public double StepTarget { get; set; }
        [DataMember(Name = "sleep_target_mins")]
        public double SleepTargetMins { get; set; }
    }
}
