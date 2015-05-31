namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_AdminRolePriv
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int roleid { get; set; }

        [StringLength(30)]
        public string m { get; set; }

        [StringLength(30)]
        public string c { get; set; }

        [StringLength(50)]
        public string a { get; set; }
    }
}
