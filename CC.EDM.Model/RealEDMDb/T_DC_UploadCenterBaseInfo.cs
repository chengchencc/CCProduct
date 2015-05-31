namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DC_UploadCenterBaseInfo
    {
        public long ID { get; set; }

        [Required]
        [StringLength(10)]
        public string F_UploadCenterID { get; set; }

        [Required]
        [StringLength(50)]
        public string F_UploadCenterName { get; set; }

        [StringLength(50)]
        public string F_IP { get; set; }

        [StringLength(10)]
        public string F_Port { get; set; }

        public decimal? F_Inteval { get; set; }

        [StringLength(50)]
        public string F_PWD { get; set; }

        [StringLength(10)]
        public string F_Starttime { get; set; }

        public int? F_State { get; set; }
    }
}
