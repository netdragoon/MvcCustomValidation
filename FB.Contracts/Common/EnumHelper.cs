using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FB.Contracts.Common
{
    public static class EnumHelper
    {
        public static string ToMetadata(this Enum enumValue)
        {
            var type = enumValue.GetType().Name;
            var value = enumValue.ToString();

            return string.Format("{0}.{1}", type, value);
        }
    }
}
