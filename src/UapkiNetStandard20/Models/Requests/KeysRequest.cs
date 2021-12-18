using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests
{
    internal class KeysRequest: BaseRequest
    {
        private const string MethodName = "KEYS";
        public KeysRequest() : base(MethodName)
        {
        }
    }
}
