namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DT_EnergyItemDict_tree
    {
        [Key]
        [StringLength(5)]
        public string F_EnergyItemCode { get; set; }

        [Required]
        [StringLength(32)]
        public string F_EnergyItemName { get; set; }

        [StringLength(16)]
        public string F_ParentItemCode { get; set; }

        [Required]
        [StringLength(1)]
        public string F_EnergyItemType { get; set; }

        [Required]
        [StringLength(16)]
        public string F_EnergyItemUnit { get; set; }

        [Required]
        [StringLength(16)]
        public string F_EnergyItemFml { get; set; }

        public short F_EnergyItemState { get; set; }
    }
}
