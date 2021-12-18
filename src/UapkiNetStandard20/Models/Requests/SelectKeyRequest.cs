using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class SelectKeyRequest: BaseRequest<SelectKeyParameters>
    {
        private const string MethodName = "SELECT_KEY";
        public SelectKeyRequest(string id) : base(MethodName)
        {
            Parameters = new SelectKeyParameters()
            {
                Id = id
            };
        }
    }
}
