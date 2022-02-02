using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CertificateStatus
    {
        [EnumMember(Value = "UNDEFINED")]
        Undefined,

        [EnumMember(Value = "GOOD")]
        Good,

        [EnumMember(Value = "REVOKED")]
        Revoked,

        [EnumMember(Value = "UNKNOWN")]
        Unknown
    }
}
