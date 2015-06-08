namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_layer2")]
    public partial class tb_layer2
    {
        public int id { get; set; }

        public int idd { get; set; }

        public int fcid { get; set; }

        [Required]
        [StringLength(10)]
        public string xzb { get; set; }

        [Required]
        [StringLength(10)]
        public string yzb { get; set; }
    }
}
