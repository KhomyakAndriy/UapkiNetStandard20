using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests
{
    internal class ProvidersRequest: BaseRequest
    {
        private const string MethodName = "PROVIDERS";
        public ProvidersRequest() : base(MethodName)
        {
        }
    }
}
