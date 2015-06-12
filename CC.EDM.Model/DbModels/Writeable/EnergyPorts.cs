using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class EnergyPorts : EntityBase
    {
        [Display(Name = "端口号")]
       // [Index(IsUnique = true)]
        public string Port { get; set; }

        public virtual EnergyType Energy { get; set; }
    }

}