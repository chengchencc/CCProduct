using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CC.EDM.Model.RealEDMDb;

namespace EDMWebsite.Models.ViewModels
{
    public class QueryModel
    {
        public QueryModel()
        {
            DayResult = new List<T_EC_EnergyItemDayResult>();
            HourResult = new List<T_EC_EnergyItemHourResult>();
            MonthResult = new List<T_EC_EnergyItemMonthResult>();
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<string> EnergyType { get; set; }
        public string EnergyTypeCodes { get; set; }

        public StatisticWay StatisticWay { get; set; }

        public List<string> Buildings { get; set; }
        public List<string> Rooms { get; set; }
        public string RoomCodes { get; set; }

        public Dictionary<string, string> Result { get; set; }
        public List<T_EC_EnergyItemDayResult> DayResult { get; set; }
        public List<T_EC_EnergyItemHourResult> HourResult { get; set; }
        public List<T_EC_EnergyItemMonthResult> MonthResult { get; set; }
        public string ChartSeries { get; set; }
        public string ActiveTabId { get; set; }



    }

    public enum StatisticWay{
        逐时能耗=0,
        逐日能耗=1,
        逐月能耗=2,
        //智能选择=3
    }



    public class DayResult
    {
        public T_DT_EnergyItemDict EnergyType { get; set; }
        public T_EC_EnergyItemDayResult EnergyDayResult { get; set; }
        public T_BD_BuildBaseInfo BuildInfo { get; set; }

    }




}