using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Core;
using Xunit;

namespace UnitTest
{
    public class RestfulTest
    {
        [Fact]
        public void post()
        {
            RestfulClient httpClient = new RestfulClient();
            var url = "http://localhost:11885/GFFZ_WebService.asmx/HZJHSH";
            Dictionary<string,string> dic = new Dictionary<string,string>();
            dic.Add("dic","aaaaaa");
            var result = httpClient.Post(url, dic);
        }
    }
}
