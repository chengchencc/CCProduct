namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_MeterUseInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(14)]
        public string F_MeterID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(48)]
        public string F_MeterName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string F_MeterProdID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(12)]
        public string F_CollectionID { get; set; }

        [StringLength(32)]
        public string F_MeterAddr1 { get; set; }

        [StringLength(32)]
        public string F_MeterAddr2 { get; set; }

        [StringLength(32)]
        public string F_MeterAddr3 { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal F_Rate { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short F_State { get; set; }
    }
}
