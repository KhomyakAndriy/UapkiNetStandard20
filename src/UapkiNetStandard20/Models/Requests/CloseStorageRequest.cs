using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests
{
    internal class CloseStorageRequest: BaseRequest
    {
        private const string MethodName = "CLOSE";
        public CloseStorageRequest() : base(MethodName)
        {
        }
    }
}
