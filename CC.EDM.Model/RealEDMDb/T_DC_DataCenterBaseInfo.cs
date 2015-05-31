namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DC_DataCenterBaseInfo
    {
        public T_DC_DataCenterBaseInfo()
        {
            T_BD_BuildBaseInfo = new HashSet<T_BD_BuildBaseInfo>();
            T_DC_CityTempInfo = new HashSet<T_DC_CityTempInfo>();
        }

        [Key]
        [StringLength(10)]
        public string F_DataCenterID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_DataCenterName { get; set; }

        public short F_DataCenterType { get; set; }

        [StringLength(48)]
        public string F_DataCenterManager { get; set; }

        [StringLength(800)]
        public string F_DataCenterDesc { get; set; }

        [StringLength(48)]
        public string F_DataCenterContact { get; set; }

        [StringLength(48)]
        public string F_DataCenterTel { get; set; }

        public virtual ICollection<T_BD_BuildBaseInfo> T_BD_BuildBaseInfo { get; set; }

        public virtual ICollection<T_DC_CityTempInfo> T_DC_CityTempInfo { get; set; }
    }
}
