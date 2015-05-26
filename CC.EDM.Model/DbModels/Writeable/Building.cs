using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Building : EntityBase
    {
        [Display(Name = "编号")]
        //[Index(IsUnique = true)]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "建筑面积")]
        public decimal BuildingArea { get; set; }

        [Display(Name = "层数")]
        public int FloorCount { get; set; }

        [Display(Name = "类型")]
        public BuildingType Type { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
    public enum BuildingType
    {
        教学及辅助用房,
        生活用房,
        行政办公房,
        其他用房
    }

}