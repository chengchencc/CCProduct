using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest
{
    class WebClientTest
    {
        [Fact]
        public void test()
        {
            string URI = "http://jgxt/cwbase/WebFramework/loginsso.aspx";
            string myParameters = "usercode=chengch&password=aaaaaa&slmc=gzjg&slbh=gzjg&url=main.htm";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
            }
        }
    }
}
