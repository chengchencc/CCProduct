using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.Core;

namespace CC.Product.Domain.Services
{
    public interface IWayBookService
    {
        string GetBusIdByName(string busName);
    }
    public class WayBookService : IWayBookService
    {
        public string GetBusIdByName(string busName)
        {
            RestfulClient httpClient = new RestfulClient();
            var a = httpClient.Get("http://60.216.101.229/server-ue2/rest/buslines/simple/370100/"+busName+"/0/20");


            return "ChengChen";
        }
    }
}
