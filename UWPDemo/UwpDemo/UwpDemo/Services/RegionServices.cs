using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayBook.Common;
using Windows.Data.Json;

namespace WayBook.Services
{
   public class RegionServices
    {
        const string REGION_CODE = "RegionCode";
        public const string REGION_HOST_URL = "http://www.iwaybook.com/server-ue2/rest/servers-v2/regionCode";

        private DataServices _dataService;
        public RegionServices()
        {
            _dataService = new DataServices();
        }

        public void AddOrUpdate(string regionCode)
        {
            _dataService.AddOrUpdate(REGION_CODE, regionCode);
        }

        public string Get()
        {
            var result = string.Empty;
            if (_dataService.Get(REGION_CODE)!=null)
            {
                result = _dataService.Get(REGION_CODE).ToString();
            }
            return result;
        }

        public async Task<string> GetRegionHost(string regionCode)
        {
            string host = string.Empty;
            var url = REGION_HOST_URL.Replace("regionCode", regionCode);
            var response =await RestfulClient.Get(url);
            if (response.Status != System.Net.HttpStatusCode.OK)
            {
                return string.Empty;
            }
            else
            {
                JsonObject jsonObject = JsonObject.Parse(response.Content);
                var statusObject = jsonObject["status"].GetObject();
                var statusCode = statusObject["code"].GetNumber();
                if (statusCode == 0)
                {
                    var resultObject = jsonObject["result"].GetObject();
                    var funcString = resultObject["functions"].GetString();
                    JsonObject funcObject = JsonObject.Parse(funcString);
                    var busObject = funcObject["bus"].GetObject();
                    host = busObject["httpAddr"].GetString();
                    //host = resultObject["httpAddr"].GetString();
                }
            }
            return host;
        }


    }
}
