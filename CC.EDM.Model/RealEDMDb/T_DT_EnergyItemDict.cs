namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DT_EnergyItemDict
    {
        public T_DT_EnergyItemDict()
        {
            T_EC_EnergyItemDayResult = new HashSet<T_EC_EnergyItemDayResult>();
            T_EC_EnergyItemHourResult = new HashSet<T_EC_EnergyItemHourResult>();
            T_EC_EnergyItemResult = new HashSet<T_EC_EnergyItemResult>();
            T_EC_RoomEnergyItemDayResult = new HashSet<T_EC_RoomEnergyItemDayResult>();
            T_EC_RoomEnergyItemHourResult = new HashSet<T_EC_RoomEnergyItemHourResult>();
            T_EC_RoomEnergyItemMonthResult = new HashSet<T_EC_RoomEnergyItemMonthResult>();
            T_EC_RoomEnergyItemResult = new HashSet<T_EC_RoomEnergyItemResult>();
            T_EC_UnitEnergyItemDayResult = new HashSet<T_EC_UnitEnergyItemDayResult>();
            T_EC_UnitEnergyItemHourResult = new HashSet<T_EC_UnitEnergyItemHourResult>();
            T_EC_UnitEnergyItemResult = new HashSet<T_EC_UnitEnergyItemResult>();
        }

        [Key]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        [Required]
        [StringLength(32)]
        public string F_EnergyItemName { get; set; }

        [StringLength(16)]
        public string F_ParentItemCode { get; set; }

        [Required]
        [StringLength(1)]
        public string F_EnergyItemType { get; set; }

        [Required]
        [StringLength(16)]
        public string F_EnergyItemUnit { get; set; }

        [Required]
        [StringLength(16)]
        public string F_EnergyItemFml { get; set; }

        public short F_EnergyItemState { get; set; }

        public virtual ICollection<T_EC_EnergyItemDayResult> T_EC_EnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_EnergyItemHourResult> T_EC_EnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_EnergyItemResult> T_EC_EnergyItemResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemDayResult> T_EC_RoomEnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemHourResult> T_EC_RoomEnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemMonthResult> T_EC_RoomEnergyItemMonthResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemResult> T_EC_RoomEnergyItemResult { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemDayResult> T_EC_UnitEnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemHourResult> T_EC_UnitEnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_UnitEnergyItemResult> T_EC_UnitEnergyItemResult { get; set; }
    }
}
