namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_menu1")]
    public partial class tb_menu1
    {
        public int id { get; set; }

        public int? pid { get; set; }

        public int idd { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string remark { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [StringLength(65535)]
        public string url { get; set; }
    }
}
