using System;

namespace UapkiNetStandard20.Utils
{
    internal class ConvertExtension
    {
        public static byte[] FromBase64OrNull(string base64String)
        {
            if (base64String == null)
            {
                return null;
            }
            else if (string.IsNullOrWhiteSpace(base64String))
            {
                return Array.Empty<byte>();
            }
            return Convert.FromBase64String(base64String);
        }
    }
}
