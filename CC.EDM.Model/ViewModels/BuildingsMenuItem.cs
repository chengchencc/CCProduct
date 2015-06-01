using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.EDM.Model.RealEDMDb;

namespace EDMWebsite.Models.ViewModels
{
    public class BuildingsMenuItem
    {
        public BuildingsMenuItem()
        {
            BuildingList = new List<T_BD_BuildBaseInfo>();
        }
        public BuildTypeInit BuildingType { get; set; }
        public List<T_BD_BuildBaseInfo> BuildingList { get; set; }
    }




}