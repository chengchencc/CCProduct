namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_RoomEnergyItemMonthResult
    {
        [Key]
        [StringLength(20)]
        public string F_MonthResultID { get; set; }

        [Required]
        [StringLength(10)]
        public string F_RoomID { get; set; }

        [Required]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        public DateTime F_Month { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_MonthValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_MonthEquValue { get; set; }

        public DateTime F_HourMaxStart { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_HourMaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HourMaxEquValue { get; set; }

        public DateTime F_HourMinStart { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_HourMinValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HourMinEquValue { get; set; }

        public DateTime F_DayMaxStart { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_DayMaxValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_DayMaxEquValue { get; set; }

        public DateTime F_DayMinStart { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_DayMinValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_DayMinEquValue { get; set; }

        public short F_State { get; set; }

        public virtual T_DT_EnergyItemDict T_DT_EnergyItemDict { get; set; }

        public virtual T_RM_RoomInfo T_RM_RoomInfo { get; set; }
    }
}
