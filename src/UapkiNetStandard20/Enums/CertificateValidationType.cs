using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace UapkiNetStandard20.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CertificateValidationType
    {
        [EnumMember(Value = "CRL")]
        Crl,

        [EnumMember(Value = "OCSP")]
        Ocsp,
    }
}
