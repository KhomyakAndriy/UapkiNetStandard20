using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VerificationStatus
    {
        [EnumMember(Value = "VALID")]
        Valid,

        [EnumMember(Value = "INVALID")]
        Invalid,

        [EnumMember(Value = "FAILED")]
        Failed
    }
}
