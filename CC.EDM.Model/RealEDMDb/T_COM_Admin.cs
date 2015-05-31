namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_Admin
    {
        public int id { get; set; }

        [StringLength(15)]
        public string username { get; set; }

        [StringLength(32)]
        public string userpass { get; set; }

        public int? userid { get; set; }

        public DateTime? addtime { get; set; }

        public int? roleid { get; set; }

        [StringLength(20)]
        public string lastloginip { get; set; }

        public DateTime? lastlogintime { get; set; }

        [StringLength(40)]
        public string email { get; set; }

        [StringLength(50)]
        public string realname { get; set; }

        public bool? disabled { get; set; }
    }
}
