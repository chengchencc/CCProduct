namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_CircuitEnergyItemMonthResult
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(26)]
        public string F_MonthResultID { get; set; }

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
        public DateTime F_StartMonth { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime F_EndMonth { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal F_MonthValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MonthEquValue { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime F_HourMaxStart { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal F_HourMaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HourMaxEquValue { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime F_HourMinStart { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal F_HourMinValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HourMinEquValue { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime F_DayMaxStart { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal F_DayMaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_DayMaxEquValue { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime F_DayMinStart { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "numeric")]
        public decimal F_DayMinValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_DayMinEquValue { get; set; }

        [Key]
        [Column(Order = 14)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short F_State { get; set; }
    }
}
