using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Core;
using Newtonsoft.Json;
using CC.Product.ViewModels;

namespace CC.Product.Domain.Services
{
    public interface IWayBookService
    {
        Bus GetBusIdByName(string busName);
        string GetRealTimeBuses(string busId);
    }
    public class WayBookService : IWayBookService
    {
        public Bus GetBusIdByName(string busName)
        {
            RestfulClient httpClient = new RestfulClient();
            var response = httpClient.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/"+busName+"/0/20");
            var buses = JsonConvert.DeserializeObject<Bus>(response);

            return buses;
        }

        public string GetRealTimeBuses(string busId)
        {
            RestfulClient httpClient = new RestfulClient();
            var result = httpClient.Get("http://60.216.101.229/server-ue2/rest/buses/busline/370100/"+busId);
            return result;
        }

    }
}
