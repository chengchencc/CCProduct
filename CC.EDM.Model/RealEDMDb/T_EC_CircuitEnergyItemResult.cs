namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_CircuitEnergyItemResult
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string F_ResultID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string F_CircuitID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime F_StartTime { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime F_EndTime { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal F_Value { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_EquValue { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short F_State { get; set; }
    }
}
