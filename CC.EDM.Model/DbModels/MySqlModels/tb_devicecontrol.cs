namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_devicecontrol")]
    public partial class tb_devicecontrol
    {
        public int id { get; set; }

        public int idd { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string command { get; set; }

        [StringLength(10)]
        public string port { get; set; }

        [StringLength(20)]
        public string macip { get; set; }

        [StringLength(4)]
        public string action { get; set; }
    }
}
