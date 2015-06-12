using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class SyncDataLog : EntityBase
    {
        public string SyncItemId { get; set; }
        public SyncType SyncType { get; set; }
        public string SyncError { get; set; }
    }

    public enum SyncType
    {
        EnergyItemResult,
        EnergyItemDayResult,
        EnergyItemHourResult,
        EnergyItemMonthResult,
        Others
    }
}