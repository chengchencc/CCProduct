namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_date_t")]
    public partial class tb_date_t
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string macip { get; set; }

        [Required]
        [StringLength(50)]
        public string command { get; set; }

        [Column(TypeName = "char")]
        [Required]
        [StringLength(1)]
        public string state { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime time { get; set; }
    }
}
