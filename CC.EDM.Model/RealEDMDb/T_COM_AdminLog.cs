namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_AdminLog
    {
        [Key]
        public int logid { get; set; }

        public DateTime? addtime { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        [StringLength(20)]
        public string userip { get; set; }

        public bool? isok { get; set; }
    }
}
