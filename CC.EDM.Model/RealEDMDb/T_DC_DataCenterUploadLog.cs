namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DC_DataCenterUploadLog
    {
        public long ID { get; set; }

        [Required]
        [StringLength(6)]
        public string F_DataCenterID { get; set; }

        [Required]
        [StringLength(50)]
        public string F_DataCenterName { get; set; }

        [StringLength(20)]
        public string F_UploadDest { get; set; }

        public DateTime F_UploadDatetime { get; set; }

        [StringLength(100)]
        public string F_UploadFile { get; set; }

        [StringLength(20)]
        public string F_State { get; set; }
    }
}
