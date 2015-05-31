namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_UnitZhiBiao
    {
        public int id { get; set; }

        public int? year { get; set; }

        public int? month { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? goodvalue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? maxvalue { get; set; }

        [StringLength(10)]
        public string unid { get; set; }

        [StringLength(5)]
        public string nhtype { get; set; }
    }
}
