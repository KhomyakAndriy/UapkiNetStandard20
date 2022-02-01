using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class CrlInfoRequest: BaseRequest<CrlInfoParameters>
    {
        private const string MethodName = "CRL_INFO";
        public CrlInfoRequest(byte[] crlBytes) : base(MethodName)
        {
            Parameters = new CrlInfoParameters()
            {
                BytesBase64 = Convert.ToBase64String(crlBytes)
            };
        }
    }
}
