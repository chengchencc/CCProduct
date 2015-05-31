namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_AlarmSet
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string F_BuildID { get; set; }

        [StringLength(50)]
        public string F_BuildName { get; set; }

        [StringLength(10)]
        public string F_RoomID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        [StringLength(50)]
        public string F_EnergyItemName { get; set; }

        [Key]
        [Column(Order = 3)]
        public double F_maxcapacity { get; set; }
    }
}
