using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Product.ViewModels
{
    public class Bus
    {
        public Status status { get; set; }
        public BusResult result { get; set; }
    }
    public class Status {
        public int code { get; set; }
    }
    public class BusResult
    {
        public PageParam pageParam { get; set; }
        public List<ResultItem> result { get; set; }
    }
    public class PageParam
    {
        public int offset { get; set; }
        public int len { get; set; }
        public int totalNum { get; set; }
    }
    public class ResultItem
    {
        public string id { get; set; }
        public string localLineId { get; set; }
        public string endStationName { get; set; }
        public string lineName { get; set; }
        public string startStationName { get; set; }
        public DateTime updateTime { get; set; }
    }
}