using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests
{
    internal class InitKeyUsageRequest: BaseRequest<object>
    {
        private const string MethodName = " INIT_KEY_USAGE";
        public InitKeyUsageRequest(object parameters) : base(MethodName)
        {
            Parameters = parameters;
        }
    }
}
