using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.EDM.Model.RealEDMDb;

namespace EDMWebsite.Models.ViewModels
{
    //[JsonProperty(PropertyName = "FooBar")]
    public class ChartSeriesItem
    {
        public ChartSeriesItem()
        {
            data = new List<ChartSeriesDataItem>();
        }
        public string name { get; set; }
        public bool colorByPoint { get; set; }
        public List<ChartSeriesDataItem> data { get; set; }
    }

    public class ChartSeriesDataItem
    {
        public string name { get; set; }
        public decimal y { get; set; }
        //public decimal x { get; set; }
        //public string drilldown { get; set; }
        //public bool selected { get; set; }
        public string id { get; set; }
        //public string color { get; set; }
        //public string dataLabels { get; set; }
        
    }
}