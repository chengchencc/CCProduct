using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    [Table("DbFirstTest")]
    public class DbFirstTest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }

    }
}