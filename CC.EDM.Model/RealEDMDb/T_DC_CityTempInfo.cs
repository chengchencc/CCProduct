namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DC_CityTempInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string F_DataCenterID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string F_DistrictCode { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime F_StartTime { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime F_EndTime { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_TempValue { get; set; }

        public virtual T_DC_DataCenterBaseInfo T_DC_DataCenterBaseInfo { get; set; }
    }
}
