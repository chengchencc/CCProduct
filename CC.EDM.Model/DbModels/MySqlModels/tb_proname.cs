namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_proname")]
    public partial class tb_proname
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string proname { get; set; }

        [Required]
        [StringLength(20)]
        public string prouser { get; set; }
    }
}
