namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_EC_EnergyItemReal
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(26)]
        public string F_ResultID { get; set; }

        [StringLength(30)]
        public string F_CollectorName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [StringLength(5)]
        public string F_RoomID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime F_StartTime { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "numeric")]
        public decimal F_Value { get; set; }
    }
}
