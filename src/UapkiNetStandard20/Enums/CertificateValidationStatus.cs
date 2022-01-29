using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
