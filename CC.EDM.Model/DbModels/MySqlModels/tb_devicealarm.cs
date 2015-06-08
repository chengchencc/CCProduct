namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_devicealarm")]
    public partial class tb_devicealarm
    {
        public int id { get; set; }

        public int idd { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [StringLength(65535)]
        public string condition { get; set; }

        public int outputid { get; set; }

        [Required]
        [StringLength(1)]
        public string state { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime time { get; set; }
    }
}
