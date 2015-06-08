namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_deviceoutput")]
    public partial class tb_deviceoutput
    {
        public int id { get; set; }

        public int idd { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string name { get; set; }

        [StringLength(20)]
        public string port { get; set; }

        [StringLength(20)]
        public string macip { get; set; }

        [StringLength(6)]
        public string value { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string formula { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime time { get; set; }
    }
}
