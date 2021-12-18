using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UapkiNetStandard20.Utils
{
    public static class EnumHelper
    {
        public static string GetDescription<T>(this T enumVal) where T: Enum
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ?  ((DescriptionAttribute)attributes[0]).Description : null;
        }
    }
}
