namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_CircuitBaseInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(13)]
        public string F_CircuitID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string F_DistributeRoomID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string F_DistributeRoomName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string F_CircuitName { get; set; }

        [StringLength(2)]
        public string F_Type { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short F_State { get; set; }
    }
}
