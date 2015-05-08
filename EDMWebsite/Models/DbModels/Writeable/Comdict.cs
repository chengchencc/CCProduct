using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Comdict
    {
        public Comdict()
        {
            CreateDate = DateTime.Now;
        }
        public Comdict(string type,string key,string value)
        {
            Type = type;
            Key = key;
            Value = value;
            CreateDate = DateTime.Now;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public DateTime CreateDate { get; set; }

    }
}