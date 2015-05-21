using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Institute:EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int PeopleCount { get; set; }
        public virtual List<Room> Rooms { get; set; }


    }
}