namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_RM_RoomInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string F_UnitID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string F_RoomID { get; set; }

        [Required]
        [StringLength(20)]
        public string F_RoomName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F_RoomArea { get; set; }

        public int? F_PeopleNum { get; set; }

        public DateTime? F_CreateTime { get; set; }

        public short F_State { get; set; }

        public virtual T_BD_BuildBaseInfo T_BD_BuildBaseInfo { get; set; }

        public virtual T_UT_UnitBaseInfo T_UT_UnitBaseInfo { get; set; }
    }
}
