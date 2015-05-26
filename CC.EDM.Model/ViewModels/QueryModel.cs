using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.ViewModels
{
    public class QueryModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string>  EnergyType{ get; set; }
        public string EnergyTypeCodes { get; set; }
        public Dictionary<string,string> Result { get; set; }
    }
}