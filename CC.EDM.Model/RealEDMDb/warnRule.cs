namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("warnRule")]
    public partial class warnRule
    {
        public int id { get; set; }

        [Required]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? elec { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? water { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? heat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? gas { get; set; }
    }
}
