using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WayBook.Common;
using Windows.Data.Json;

namespace WayBook.Services
{
    public class UrlServices
    {
        public const string BUS_LINE_URL = "http://host/server-ue2/rest/buslines/simple/regionCode/busCode/0/20";
        public const string STATIONS_URL = "http://host/server-ue2/rest/buslines/regionCode/busId";
        public const string REALTIME_BUSES_URL = "http://host/server-ue2/rest/buses/busline/regionCode/busId";

        private RegionServices _rs;
        private string _host;
        public UrlServices()
        {
            _rs = new RegionServices();
            _host = DataServices.Instance.Get("Host").ToString();
        }


        public string RegionCode
        {
            get
            {
                return _rs.Get();
            }
        }

        public string GetBusLineUrl(string busCode)
        {
            string regionCode = this.RegionCode;
            return GetBusLineUrl(regionCode, busCode);
        }

        public string GetBusLineUrl(string regionCode, string busCode)
        {
            return BUS_LINE_URL.Replace("regionCode", regionCode).Replace("busCode", busCode).Replace("host",_host);
        }

        public string GetStationsUrl(string busId)
        {
            var regionCode = this.RegionCode;
            return GetStationsUrl(regionCode, busId);
        }
        public string GetStationsUrl(string regionCode, string busId)
        {
            return STATIONS_URL.Replace("regionCode", regionCode).Replace("busId", busId).Replace("host",_host);
        }
        public string GetRealtimeBusesUrl(string busId)
        {
            string regionCode = this.RegionCode;
            return GetRealtimeBusesUrl(regionCode, busId);
        }
        public string GetRealtimeBusesUrl(string regionCode, string busId)
        {
            return REALTIME_BUSES_URL.Replace("regionCode", regionCode).Replace("busId", busId).Replace("host",_host);
        }

        public static UrlServices Instance
        {
            get { return new UrlServices(); }
        }

        public void RegionHostDictionary()
        {
            Dictionary<string, string> Region = new Dictionary<string, string>();
            Region.Add("460200", "sanya.iwaybook.com:18087");//三亚
            Region.Add("320281", "haisen.iwaybook.com");//江阴
            Region.Add("321200", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
            Region.Add("", "");//
        }



    }

    public class RegionHostData
    {
        public int status { get; set; }
        public RegionHostResultData result { get; set; }
    }
    public class RegionHostResultData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string httpAddr { get; set; }

    }
    public class RegionHostFunctions
    {

    }

}
