using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace WayBook.Common
{
    public class HttpClientWapper : Singleton<HttpClientWapper>
    {
        private HttpClient httpClient;
        public HttpClientWapper()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 10);//set Timeout to 10s
        }

        public async Task<string> Get(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("url为空！");
            }
            var uri = new Uri(url);
            //httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            try
            {
                var responseByteArray = await httpClient.GetByteArrayAsync(uri);
                var resultString = Encoding.GetEncoding("UTF-8").GetString(responseByteArray, 0, responseByteArray.Length);
                return resultString;
            }
            catch (Exception)
            {
                throw new Exception(Utilities.GetStringFromResource("NetworkConnectionError"));
                //return string.Empty;
            }

        }
        public string Post(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("url为空！");
            }
            var uri = new Uri(url);
            //httpClient.PostAsync(uri, content);
            return string.Empty;
        }


    }
}
