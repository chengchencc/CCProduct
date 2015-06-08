namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_data")]
    public partial class tb_data
    {
        public long id { get; set; }

        [StringLength(20)]
        public string macip { get; set; }

        [StringLength(20)]
        public string port { get; set; }

        [StringLength(6)]
        public string value { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime time { get; set; }
    }
}
