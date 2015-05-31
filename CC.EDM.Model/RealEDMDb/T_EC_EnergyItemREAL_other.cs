namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_EnergyItemREAL_other
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        public DateTime? F_StartTime { get; set; }

        public DateTime? F_EndTime { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal F_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_EquValue { get; set; }

        public short? F_State { get; set; }
    }
}
