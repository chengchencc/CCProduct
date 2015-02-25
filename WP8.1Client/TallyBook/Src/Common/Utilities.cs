using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Product.TallyBook.Common
{
    public static class Utilities
    {
        public static decimal StringToDecimal(string value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return 0m;
            }

        }

    }
}
