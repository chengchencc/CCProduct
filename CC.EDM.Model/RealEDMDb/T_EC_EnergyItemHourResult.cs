namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_EnergyItemHourResult
    {
        [Key]
        [StringLength(25)]
        public string F_HourResultID { get; set; }

        [Required]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Required]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        public DateTime F_StartHour { get; set; }

        public DateTime F_EndHour { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F_HourValue { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_HourEquValue { get; set; }

        public short F_State { get; set; }

        public virtual T_BD_BuildBaseInfo T_BD_BuildBaseInfo { get; set; }

        public virtual T_DT_EnergyItemDict T_DT_EnergyItemDict { get; set; }
    }
}
