using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Institute:EntityBase
    {
        [Display(Name = "编号")]
        //[Index(IsUnique = true)]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "总人数")]
        public int PeopleCount { get; set; }
        public virtual List<Room> Rooms { get; set; }


    }
}