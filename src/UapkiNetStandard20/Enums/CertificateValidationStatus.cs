using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CertificateValidationStatus
    {
        [EnumMember(Value = "UNDEFINED")]
        Undefined,

        [EnumMember(Value = "NOT PRESENT")]
        NotPresent,

        [EnumMember(Value = "FAILED")]
        Failed,

        [EnumMember(Value = "INVALID")]
        Invalid,

        [EnumMember(Value = "VALID")]
        Valid
    }
}
