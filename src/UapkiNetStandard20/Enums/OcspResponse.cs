using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OcspResponse
    {
        [EnumMember(Value = "UNDEFINED")]
        Undefined,

        [EnumMember(Value = "SUCCESSFUL")]
        Successful,

        [EnumMember(Value = "MALFORMED_REQUEST")]
        MalformedRequest,

        [EnumMember(Value = "INTERNAL_ERROR")]
        InternalError,

        [EnumMember(Value = "TRY_LATER")]
        TryLater,

        [EnumMember(Value = "SIG_REQUIRED")]
        SignatureRequired,

        [EnumMember(Value = "UNAUTHORIZED")]
        Unauthorized,
    }
}
