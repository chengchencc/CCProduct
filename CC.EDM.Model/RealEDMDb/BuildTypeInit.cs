namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BuildTypeInit")]
    public partial class BuildTypeInit
    {
        [Key]
        [Column(Order = 0)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string typename { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string contain { get; set; }

        public int? flag { get; set; }
    }
}
