using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Product.ViewModels.WayBook
{
    public class StationInfo
    {
        public string id { get; set; }
        public int area { get; set; }
        public string localLineId { get; set; }
        public string endStationName { get; set; }
        public string lineName { get; set; }
        public string linePoints { get; set; }
        public string startStationName { get; set; }
        public string state { get; set; }
        public string stationList { get; set; }
        public List<Station> stations { get; set; }
        public string ticketPrice { get; set; }
        public string operationTime { get; set; }
        public string owner { get; set; }
        public DateTime updateTime { get; set; }
        public string descrip { get; set; }
    }
    public class Station {
        public string id { get; set; }
        public string area { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public string state { get; set; }
        public string stationName { get; set; }
        public DateTime updateTime { get; set; }
    
    }
}
