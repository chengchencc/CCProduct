using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Product.Core.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToDateTimeWithFullTime(this string value)
        {
            var result = DateTime.ParseExact(value, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }
        public static DateTime ToDateTimeWithDate(this string value)
        {
            var result = DateTime.ParseExact(value, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            return result;
        }

    }
}
