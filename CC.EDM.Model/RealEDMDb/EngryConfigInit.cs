namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EngryConfigInit")]
    public partial class EngryConfigInit
    {
        public int id { get; set; }

        [StringLength(31)]
        public string FBuildID { get; set; }

        [StringLength(10)]
        public string tjlx { get; set; }

        [StringLength(1000)]
        public string nhdm { get; set; }

        [StringLength(20)]
        public string tjmd { get; set; }

        [StringLength(10)]
        public string xsfs { get; set; }

        [StringLength(10)]
        public string xsfsxx { get; set; }
    }
}
