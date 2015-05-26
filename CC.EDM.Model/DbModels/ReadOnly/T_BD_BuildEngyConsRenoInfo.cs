namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_BuildEngyConsRenoInfo
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime F_RenoDate { get; set; }

        [Required]
        [StringLength(64)]
        public string F_RenoDept { get; set; }

        [StringLength(800)]
        public string F_RenoDesc { get; set; }

        public virtual T_BD_BuildBaseInfo T_BD_BuildBaseInfo { get; set; }
    }
}
