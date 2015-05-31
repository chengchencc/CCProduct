namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_US_UserInfo
    {
        [Key]
        [StringLength(20)]
        public string F_UserName { get; set; }

        [StringLength(50)]
        public string F_Role { get; set; }

        [StringLength(50)]
        public string F_PWD { get; set; }
    }
}
