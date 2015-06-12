using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CC.Product.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToStringWithFullTime(this DateTime value)
        {
            var result = value.ToString("yyyyMMddHHmmss");
            return result;
        }
        public static string ToStringWithDate(this DateTime value)
        {
            var result = value.ToString("yyyyMMdd");
            return result;
        }

    }
}
