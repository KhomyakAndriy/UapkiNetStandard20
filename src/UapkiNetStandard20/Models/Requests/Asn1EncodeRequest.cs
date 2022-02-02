using System.Collections.Generic;
using UapkiNetStandard20.Models.Asn1;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class Asn1EncodeRequest : BaseRequest<Asn1EncodeParameters>
    {
        private const string MethodName = "ASN1_ENCODE";
        public Asn1EncodeRequest(List<ItemToEncode> items) : base(MethodName)
        {
            Parameters = new Asn1EncodeParameters()
            {
                Items = items
            };
        }
    }
}
