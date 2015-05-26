namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_DataCollectionInfo
    {
        [Key]
        [StringLength(12)]
        public string F_CollectionID { get; set; }

        [Required]
        [StringLength(10)]
        public string F_BuildID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_CollectionName { get; set; }

        [Required]
        [StringLength(200)]
        public string F_CollectionURL { get; set; }

        public DateTime F_CollectStartTime { get; set; }

        public int F_CollectInterval { get; set; }

        public short F_State { get; set; }
    }
}
