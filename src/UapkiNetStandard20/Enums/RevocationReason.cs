using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RevocationReason
    {
        [EnumMember(Value = "UNDEFINED")]
        Undefined,

        [EnumMember(Value = "UNSPECIFIED")]
        Unspecified,

        [EnumMember(Value = "KEY_COMPROMISE")]
        KeyCompromise,

        [EnumMember(Value = "CA_COMPROMISE")]
        CaCompromise,

        [EnumMember(Value = "AFFILIATION_CHANGED")]
        AddilationChanged,

        [EnumMember(Value = "SUPERSEDED")]
        Superseded,

        [EnumMember(Value = "CESSATION_OF_OPERATION")]
        CessationOfOperation,

        [EnumMember(Value = "CERTIFICATE_HOLD")]
        CertificateHold,

        [EnumMember(Value = "REMOVE_FROM_CRL")]
        RemovedFromCrl,

        [EnumMember(Value = "PRIVILEGE_WITHDRAWN")]
        PrivilegeWithdrawn,

        [EnumMember(Value = "AA_COMPROMISE")]
        AaCompromise,
    }
}
