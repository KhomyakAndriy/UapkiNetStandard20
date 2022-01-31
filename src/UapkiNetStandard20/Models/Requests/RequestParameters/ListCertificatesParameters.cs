using System;
using System.Collections.Generic;
using System.Text;

namespace UapkiNetStandard20.Models.Requests.RequestParameters
{
    internal class ListCertificatesParameters
    {
        public int Offset { get; set; }

        public int? PageSize { get; set; }
    }
}
