using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SignatureFormat
    {
        [EnumMember(Value = "RAW")]
        Raw,

        [EnumMember(Value = "CMS")]
        Cms,

        [EnumMember(Value = "CAdES-T")]
        CadesT,

        [EnumMember(Value = "CAdES-BES")]
        CadesBes
    }
}
