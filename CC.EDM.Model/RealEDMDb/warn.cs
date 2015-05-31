namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("warn")]
    public partial class warn
    {
        public int id { get; set; }

        [Required]
        [StringLength(13)]
        public string F_buildID { get; set; }

        public DateTime? time { get; set; }

        [StringLength(50)]
        public string warnType { get; set; }

        [StringLength(250)]
        public string remark { get; set; }

        [StringLength(1)]
        public string status { get; set; }
    }
}
