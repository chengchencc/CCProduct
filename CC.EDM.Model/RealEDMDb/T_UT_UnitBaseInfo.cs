namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_UT_UnitBaseInfo
    {
        public T_UT_UnitBaseInfo()
        {
            T_EC_UnitEnergyItemDayResult = new HashSet<T_EC_UnitEnergyItemDayResult>();
            T_EC_UnitEnergyItemHourResult = new HashSet<T_EC_UnitEnergyItemHourResult>();
            T_EC_UnitEnergyItemResult = new HashSet<T_EC_UnitEnergyItemResult>();
            T_RM_RoomInfo = new HashSet<T_RM_RoomInfo>();
        }

        [Key]
        [StringLength(10)]
        public string F_UnitID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_UnitName { get; set; }

        [Required]
        [StringLength(16)]
        public string F_AliasName { get; set; }

        public short F_State { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_TotalArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_AirArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HeatArea { get; set; }

        public DateTime F_CreateTime { get; set; }

        [StringLength(32)]
        public string F_CreateUser { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemDayResult> T_EC_UnitEnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemHourResult> T_EC_UnitEnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemResult> T_EC_UnitEnergyItemResult { get; set; }

        public virtual ICollection<T_RM_RoomInfo> T_RM_RoomInfo { get; set; }
    }
}
