using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    class EncoderTest
    {
        [Fact]
        public void test()
        {

            var str = CC.Product.Core.Utilities.Encoder.GetMD5FromString("qinqiao" + "portal");
            var str1 = CC.Product.Core.Utilities.Encoder.GetMD5FromString("portal" + "qinqiao");

        }

    }


}
