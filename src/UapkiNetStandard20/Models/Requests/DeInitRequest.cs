using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests
{
    internal class DeInitRequest: BaseRequest
    {
        private const string MethodName = "DEINIT";
        public DeInitRequest() : base(MethodName)
        {
        }
    }
}
