namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_AdminRole
    {
        [Key]
        public int roleid { get; set; }

        [Required]
        [StringLength(50)]
        public string rolename { get; set; }

        [StringLength(550)]
        public string description { get; set; }

        public int? listorder { get; set; }

        public bool? issys { get; set; }
    }
}
