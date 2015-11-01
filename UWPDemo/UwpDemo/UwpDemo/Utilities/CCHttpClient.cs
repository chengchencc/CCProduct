using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace UwpDemo.Utilities
{
    public class CCHttpClient
    {
        HttpClient httpClient;
        public CCHttpClient()
        {
            httpClient = new HttpClient();
        }
        public async Task<string> GetString(string url)
        {
            var responseBytes = await httpClient.GetByteArrayAsync(url);
            var result = Encoding.UTF8.GetString(responseBytes);
            return result;
        }

        public void CancleAllRequest()
        {
            httpClient.CancelPendingRequests();
        }


    }
}
