namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_CircuitMeterInfo
    {
        [Key]
        [StringLength(14)]
        public string F_CircuitID { get; set; }

        [Required]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Required]
        [StringLength(14)]
        public string F_ParentID { get; set; }

        [Required]
        [StringLength(14)]
        public string F_MeterID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_CircuitName { get; set; }

        public short F_State { get; set; }
    }
}
