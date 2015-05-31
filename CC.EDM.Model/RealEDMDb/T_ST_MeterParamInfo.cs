namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_MeterParamInfo
    {
        [Key]
        [StringLength(16)]
        public string F_MeterParamID { get; set; }

        [Required]
        [StringLength(12)]
        public string F_MeterProdID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_MeterParamName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_ChangeRate { get; set; }

        [Required]
        [StringLength(1)]
        public string F_ValueType { get; set; }

        public short F_State { get; set; }
    }
}
