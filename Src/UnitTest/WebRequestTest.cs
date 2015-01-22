using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xunit;

namespace UnitTest
{
    class WebRequestTest
    {
        [Fact]
        public void Test()
        {
            //var req = (HttpWebRequest)WebRequest.Create("http://localhost:2015/");
            var req = (HttpWebRequest)WebRequest.Create("http://localhost:11885/GFFZ_WebService.asmx/HZJHSH");
            req.ContentType = "text/xml;encoding='utf-8'";
            var rep = (HttpWebResponse)req.GetResponse();//此时程序才开始向目标网页发送Post请求  
            if (rep.StatusCode == HttpStatusCode.OK)
            {
                Stream repStream = null;
                //得到回应过来的流
                repStream = rep.GetResponseStream();

                var streamReader = new StreamReader(repStream);
                var res = streamReader.ReadToEnd();
                streamReader.Close();
                //Load response stream into XMLReader
                //objXmlReader = new XmlTextReader(repStream);
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(res);
                //xmldoc.Load(objXmlReader);
                
            }

        }
    }
}
