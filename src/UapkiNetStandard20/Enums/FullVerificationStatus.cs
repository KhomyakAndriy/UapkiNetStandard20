using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FullVerificationStatus
    {
        [EnumMember(Value = "INDETERMINATE")]
        Indeterminate,

        [EnumMember(Value = "TOTAL-FAILED")]
        TotalFailed,

        [EnumMember(Value = "TOTAL-VALID")]
        TotalValid
    }
}
