using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class StoragesRequest : BaseRequest<StoragesParameters>
    {
        private const string MethodName = "STORAGES";
        public StoragesRequest(string providerId) : base(MethodName)
        {
            Parameters = new StoragesParameters()
            {
                Provider = providerId
            };
        }
    }
}
