using System;
using System.Collections.Generic;
using System.Text;
using UapkiNetStandard20.Models.Asn1;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class Asn1DecodeRequest: BaseRequest<Asn1DecodeParameters>
    {
        private const string MethodName = "ASN1_DECODE";
        public Asn1DecodeRequest(List<ItemToDecode> itemsToDecode) : base(MethodName)
        {
            Parameters = new Asn1DecodeParameters()
            {
                Items = itemsToDecode
            };
        }
    }
}
