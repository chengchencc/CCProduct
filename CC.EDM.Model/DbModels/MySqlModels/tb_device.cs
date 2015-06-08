namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_device")]
    public partial class tb_device
    {
        public int id { get; set; }

        public int pid { get; set; }

        [Required]
        [StringLength(20)]
        public string title { get; set; }

        [StringLength(50)]
        public string image { get; set; }

        [Required]
        [StringLength(3)]
        public string type { get; set; }

        [StringLength(1)]
        public string state { get; set; }
    }
}
