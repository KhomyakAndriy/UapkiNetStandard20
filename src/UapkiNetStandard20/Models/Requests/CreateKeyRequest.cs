using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class CreateKeyRequest: BaseRequest<CreateKeyParameters>
    {
        private const string MethodName = "CREATE_KEY";
        public CreateKeyRequest(CreateKeyParameters parameters) : base(MethodName)
        {
            Parameters = parameters;
        }
    }
}
