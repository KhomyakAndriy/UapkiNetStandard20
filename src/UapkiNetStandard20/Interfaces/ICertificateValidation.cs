using System;
using UapkiNetStandard20.Enums;

namespace UapkiNetStandard20.Interfaces
{
    public interface ICertificateValidation
    {
        CertificateStatus Status { get; set; }
        RevocationReason? RevocationReason { get; set; }
        DateTime? RevocationTime { get; set; }
    }
}
