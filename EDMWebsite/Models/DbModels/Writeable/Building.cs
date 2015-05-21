using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Building : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal BuildingArea { get; set; }
        public int FloorCount { get; set; }
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