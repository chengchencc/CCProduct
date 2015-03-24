using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable;
using System.Net.NetworkInformation;

namespace WayBook.Common
{
    public class RestfulClient
    {
        /// <summary>
        /// For response, only support gbk encoding..
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeoutMilliSeconds"></param>
        /// <returns></returns>
        public static async Task<string> Get(string url, int timeoutMilliSeconds = 10000)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return string.Empty;
            }

            var content = string.Empty;
            using (var client = new RestClient(url))
            {
                try
                {
                   
                    if (timeoutMilliSeconds > 0) client.Timeout = new TimeSpan(0, 0, 0, timeoutMilliSeconds);

                    var request = new RestRequest();
                    request.Method = HttpMethod.Get;
                    request.AddHeader("cache-control", "no-cache");
                    
                    var response = await client.Execute(request);
                    if (response.RawBytes != null)
                        content = Encoding.GetEncoding(EncodingNames.UTF8).GetString(response.RawBytes, 0, response.RawBytes.Length);

                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("RestfullClient", ex.Message);
                    AppLogs.WriteError("RestfullClient", ex.StackTrace);
                }
            }
            return content;
        }
        /// <summary>
        /// For response, only support gbk encoding..
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paras"></param>
        /// <param name="timeoutMilliSconds"></param>
        /// <returns></returns>
        public static async Task<string> Post(string url, Dictionary<string, string> paras, int timeoutMilliSconds = 10000)
        {
            return await Post(url, paras, EncodingNames.GBK, timeoutMilliSconds);
        }


        public static async Task<string> Post(string url, Dictionary<string, string> paras, string resultEncoding, int timeoutMilliSconds = 0)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return string.Empty;
            }

            var content = string.Empty;
            using (var client = new RestClient(url))
            {
                try
                {
                    if (timeoutMilliSconds > 0) client.Timeout = new TimeSpan(0, 0, 0, timeoutMilliSconds);

                    var request = new RestRequest(HttpMethod.Post);
                    foreach (var param in paras)
                    {
                        request.AddParameter(param.Key, param.Value);
                    }

                    var response = await client.Execute(request);
                    content = Encoding.GetEncoding(resultEncoding).GetString(response.RawBytes, 0, response.RawBytes.Length);
                }
                catch (Exception ex)
                {
                    AppLogs.WriteError("RestfullClient.post", ex.Message);
                    AppLogs.WriteError("RestfullClient.post", ex.StackTrace);
                }
            }
            return content;

        }


    }
    public class EncodingNames
    {
        public const string GB2312 = "GB2312";
        public const string GBK = "GBK";
        public const string UTF8 = "UTF-8";
        public const string UNICODE = "Unicode";
        public const string ASCII = "ASCII";
    }
}
