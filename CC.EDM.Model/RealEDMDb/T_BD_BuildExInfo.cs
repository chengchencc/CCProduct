namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_BuildExInfo
    {
        [Key]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        public int? F_WorkerNum { get; set; }

        public int? F_CustomerNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_OpenHours { get; set; }

        [StringLength(16)]
        public string F_ServiceLevel { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HotelLiveRate { get; set; }

        public int? F_HotelBedNum { get; set; }

        public int? F_VisitorNum { get; set; }

        public int? F_StudentNum { get; set; }

        [StringLength(16)]
        public string F_HospitalStandard { get; set; }

        [StringLength(16)]
        public string F_HospitalType { get; set; }

        public int? F_PatientNum { get; set; }

        public int? F_HospitalBedNum { get; set; }

        public int? F_SpectatorNum { get; set; }

        [StringLength(800)]
        public string F_GroupFunc { get; set; }

        [StringLength(800)]
        public string F_ExtendFunc { get; set; }

        [StringLength(10)]
        public string F_ElectriPrice { get; set; }

        [StringLength(10)]
        public string F_WaterPrice { get; set; }

        [StringLength(10)]
        public string F_GasPrice { get; set; }

        [StringLength(10)]
        public string F_HeatPrice { get; set; }

        [StringLength(20)]
        public string F_OtherPrice { get; set; }

        public int? F_TotalLightingPower { get; set; }

        public int? F_TotalAirConditionHeatPower { get; set; }

        public int? F_TotalSpecialPowerPower { get; set; }

        public int? F_TotalMotivePower { get; set; }

        [StringLength(50)]
        public string F_BuildGrade { get; set; }

        public int? F_BookNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_ReadingRoomArea { get; set; }

        [StringLength(50)]
        public string F_scienceType { get; set; }

        public int? F_SeatNum { get; set; }

        [StringLength(10)]
        public string F_sitetype { get; set; }

        public int? F_DiningNum { get; set; }

        [StringLength(10)]
        public string F_DiningType { get; set; }

        public int? F_BathNum { get; set; }

        [StringLength(50)]
        public string F_TestType { get; set; }

        public virtual T_BD_BuildBaseInfo T_BD_BuildBaseInfo { get; set; }
    }
}
