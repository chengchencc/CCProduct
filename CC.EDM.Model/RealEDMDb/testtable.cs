namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("testtable")]
    public partial class testtable
    {
        [Key]
        [StringLength(10)]
        public string tt1 { get; set; }

        [StringLength(10)]
        public string tt2 { get; set; }

        public bool? tt3 { get; set; }
    }
}
