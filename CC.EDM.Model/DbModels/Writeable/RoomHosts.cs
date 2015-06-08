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

        public Room Rooms { get; set; }
    }

}