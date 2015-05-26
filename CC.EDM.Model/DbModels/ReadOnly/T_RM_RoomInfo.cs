namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_RM_RoomInfo
    {
        public T_RM_RoomInfo()
        {
            T_EC_RoomEnergyItemDayResult = new HashSet<T_EC_RoomEnergyItemDayResult>();
            T_EC_RoomEnergyItemHourResult = new HashSet<T_EC_RoomEnergyItemHourResult>();
            T_EC_RoomEnergyItemMonthResult = new HashSet<T_EC_RoomEnergyItemMonthResult>();
            T_EC_RoomEnergyItemResult = new HashSet<T_EC_RoomEnergyItemResult>();
        }

        [Required]
        [StringLength(10)]
        public string F_UnitID { get; set; }

        [Required]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Key]
        [StringLength(10)]
        public string F_RoomID { get; set; }

        [Required]
        [StringLength(20)]
        public string F_RoomName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_RoomArea { get; set; }

        public int? F_PeopleNum { get; set; }

        public DateTime? F_CreateTime { get; set; }

        public short F_State { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemDayResult> T_EC_RoomEnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemHourResult> T_EC_RoomEnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemMonthResult> T_EC_RoomEnergyItemMonthResult { get; set; }

        public virtual ICollection<T_EC_RoomEnergyItemResult> T_EC_RoomEnergyItemResult { get; set; }
    }
}
