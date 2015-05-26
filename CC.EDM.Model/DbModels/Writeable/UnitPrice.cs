using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class UnitPrice : EntityBase
    {
        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "水")]
        public decimal Water { get; set; }

        [Display(Name = "电")]
        public decimal Electricity { get; set; }

        [Display(Name = "煤")]
        public decimal Coal { get; set; }
        
        [Display(Name = "燃气")]
        public decimal Gas { get; set; }

        [Display(Name = "蒸汽")]
        public decimal Steam { get; set; }

        [Display(Name = "类型")]
        public UnitPriceType Type { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
    public enum UnitPriceType
    {
        默认,
        单独计费
    }

}