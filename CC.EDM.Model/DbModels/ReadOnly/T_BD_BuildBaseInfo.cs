namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_BuildBaseInfo
    {
        public T_BD_BuildBaseInfo()
        {
            T_BD_BuildAddFile = new HashSet<T_BD_BuildAddFile>();
            T_BD_BuildEngyConsRenoInfo = new HashSet<T_BD_BuildEngyConsRenoInfo>();
            T_EC_EnergyItemDayResult = new HashSet<T_EC_EnergyItemDayResult>();
            T_EC_EnergyItemHourResult = new HashSet<T_EC_EnergyItemHourResult>();
            T_EC_EnergyItemResult = new HashSet<T_EC_EnergyItemResult>();
            T_BD_BuildGroupBaseInfo = new HashSet<T_BD_BuildGroupBaseInfo>();
        }

        [Key]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Required]
        [StringLength(6)]
        public string F_DataCenterID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_BuildName { get; set; }

        [Required]
        [StringLength(16)]
        public string F_AliasName { get; set; }

        [Required]
        [StringLength(80)]
        public string F_BuildOwner { get; set; }

        public short F_State { get; set; }

        [Required]
        [StringLength(6)]
        public string F_DistrictCode { get; set; }

        [Required]
        [StringLength(80)]
        public string F_BuildAddr { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_BuildLong { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_BuildLat { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_BuildYear { get; set; }

        public int F_UpFloor { get; set; }

        public int? F_DownFloor { get; set; }

        [Required]
        [StringLength(1)]
        public string F_BuildFunc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_TotalArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_AirArea { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_HeatArea { get; set; }

        [Required]
        [StringLength(1)]
        public string F_AirType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_HeatType { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_BodyCoef { get; set; }

        [Required]
        [StringLength(1)]
        public string F_StruType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_WallMatType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_WallWarmType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_WallWinType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_GlassType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_WinFrameType { get; set; }

        public bool F_IsStandard { get; set; }

        [Required]
        [StringLength(64)]
        public string F_DesignDept { get; set; }

        [Required]
        [StringLength(64)]
        public string F_WorkDept { get; set; }

        public DateTime F_CreateTime { get; set; }

        [StringLength(32)]
        public string F_CreateUser { get; set; }

        public DateTime? F_MonitorDate { get; set; }

        public DateTime? F_AcceptDate { get; set; }

        public virtual ICollection<T_BD_BuildAddFile> T_BD_BuildAddFile { get; set; }

        public virtual T_DC_DataCenterBaseInfo T_DC_DataCenterBaseInfo { get; set; }

        public virtual ICollection<T_BD_BuildEngyConsRenoInfo> T_BD_BuildEngyConsRenoInfo { get; set; }

        public virtual T_BD_BuildExInfo T_BD_BuildExInfo { get; set; }

        public virtual ICollection<T_EC_EnergyItemDayResult> T_EC_EnergyItemDayResult { get; set; }

        public virtual ICollection<T_EC_EnergyItemHourResult> T_EC_EnergyItemHourResult { get; set; }

        public virtual ICollection<T_EC_EnergyItemResult> T_EC_EnergyItemResult { get; set; }

        public virtual ICollection<T_BD_BuildGroupBaseInfo> T_BD_BuildGroupBaseInfo { get; set; }
    }
}
