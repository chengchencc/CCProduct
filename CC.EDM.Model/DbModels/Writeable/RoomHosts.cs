using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class RoomHosts: EntityBase
    {
        [Display(Name="Mac地址")]
        public string Hosts { get; set; }

        [Display(Name="端口号")]
        public string Port { get; set; }

        public virtual EnergyType EnergyType { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }

}