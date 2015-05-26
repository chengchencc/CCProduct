namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_OV_MeterOrigValue
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string F_OrigValueID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(14)]
        public string F_MeterID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(16)]
        public string F_MeterParamID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(80)]
        public string F_OrigValue { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime F_CollectTime { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime F_ReceiveTime { get; set; }

        public DateTime? F_CalcTime { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short F_State { get; set; }
    }
}
