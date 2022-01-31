using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class GetCertificateRequest: BaseRequest<CertificateIdParameters>
    {
        private const string MethodName = "GET_CERT";
        public GetCertificateRequest(string certificateId) : base(MethodName)
        {
            Parameters = new CertificateIdParameters()
            {
                CertificateIdBase64 = certificateId
            };
        }
    }
}
