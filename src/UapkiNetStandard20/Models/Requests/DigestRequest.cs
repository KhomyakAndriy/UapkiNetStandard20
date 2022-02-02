using System;
using UapkiNetStandard20.Models.Requests.RequestParameters;

namespace UapkiNetStandard20.Models.Requests
{
    internal class DigestRequest: BaseRequest<DigestParameters>
    {
        private const string MethodName = "DIGEST";
        public DigestRequest(byte[] data, string algorithm, bool isHashAlgorithm) : base(MethodName)
        {
            Parameters = new DigestParameters()
            {
                BytesBase64 = Convert.ToBase64String(data)
            };
            SetAlgorithm(algorithm, isHashAlgorithm);
        }

        public DigestRequest(string filePath, string algorithm, bool isHashAlgorithm) : base(MethodName)
        {
            Parameters = new DigestParameters()
            {
                FilePath = filePath
            };
            SetAlgorithm(algorithm, isHashAlgorithm);
        }

        public DigestRequest(string ptr, int size, string algorithm, bool isHashAlgorithm) : base(MethodName)
        {
            Parameters = new DigestParameters()
            {
                PointerToMemory = ptr,
                PointerToMemorySize = size
            };
            SetAlgorithm(algorithm, isHashAlgorithm);
        }

        private void SetAlgorithm(string algorithm, bool isHashAlgorithm)
        {
            if (isHashAlgorithm)
            {
                Parameters.HashAlgorithm = algorithm;
            }
            else
            {
                Parameters.SignAlgorithm = algorithm;
            }
        }
    }
}
