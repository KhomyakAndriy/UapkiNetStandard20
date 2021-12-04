using System;

namespace UapkiNetStandard20.Common
{
    [Serializable]
    public class UapkiException: Exception
    {
        public int ErrorCode { get; }

        public UapkiException(int errorCode, string message): base(message)
        {
            ErrorCode = errorCode;
        }

        public UapkiException(int errorCode, string message, Exception innerException) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
