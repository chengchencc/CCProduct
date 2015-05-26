using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using EDMWebsite.Models.DbModels.ReadOnly;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class EnergyItemResult : EntityBase
    {
        [Display(Name = "开始时间")]
        [Index(IsUnique = true)]
        public DateTime StartDate { get; set; }

        [Display(Name = "结束时间")]
        [Index(IsUnique = true)]
        public DateTime EndDate { get; set; }

        [Display(Name = "能耗值")]
        public decimal EnergyValue { get; set; }

        [Display(Name = "能耗单位")]
        public string  EnergyUnit{ get; set; }

        //[Display(Name = "单价")]
        //public UnitPrice UnitPrice { get; set; }

        //[Display(Name = "类型")]
        //public EnergyType Type { get; set; }

        [Display(Name = "设备编号")]
        public string EnergyDeviceCode { get; set; }

        [Display(Name = "能耗类型")]
        public virtual EnergyType EnergyType { get; set; }

        public virtual Room Room { get; set; }
    }


}