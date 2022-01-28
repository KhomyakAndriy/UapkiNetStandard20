using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum  StorageOpenMode
    {
        [EnumMember(Value = "RW")]
        ReadWrite,

        [EnumMember(Value = "RO")]
        ReadOnly,

        [EnumMember(Value = "CREATE")]
        Create
    }
}
