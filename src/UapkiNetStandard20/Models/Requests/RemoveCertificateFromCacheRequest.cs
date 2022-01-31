using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class RemoveCertificateFromCacheRequest: BaseRequest<CertificateIdParameters>
    {
        private const string MethodName = "REMOVE_CERT";
        public RemoveCertificateFromCacheRequest(string certificateId) : base(MethodName)
        {
            Parameters = new CertificateIdParameters()
            {
                CertificateIdBase64 = certificateId
            };
        }
    }
}
