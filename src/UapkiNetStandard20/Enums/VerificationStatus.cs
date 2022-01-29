using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
