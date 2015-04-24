using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
//using Windows.Web.Http;
//using Windows.Web.Http.Filters;
//using Windows.Web.Http.Headers;


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
        public bool NetworkAvailability { get { return NetworkInterface.GetIsNetworkAvailable(); } }
        public async Task<string> Get(string url)
        {
            //if (!NetworkAvailability)
            //{
            //    return "无法连接到网络！";
            //}

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
            catch (Exception ex)
            {
                //throw new Exception(Utilities.GetStringFromResource("NetworkConnectionError"));
                //Utilities.ShowToast(Utilities.GetStringFromResource("NetworkConnectionError"));
                Utilities.ShowMessage(Utilities.GetStringFromResource("NetworkConnectionError"));
                return string.Empty;
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

        public static bool CheckNetworkAvailability()
        {
            // this is coming true even when i disconnected my pc from internet.
            // i also make the dataconnection off of the emulator
            var fg = NetworkInterface.GetIsNetworkAvailable();
            return fg;
            //var ni = NetworkInterface.NetworkInterfaceType;
            //// this part is coming none  
            //if (ni == NetworkInterfaceType.None)
            //    IsConnected = false;

        }

    }
}
