namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_AdminMenu
    {
        public int id { get; set; }

        [StringLength(50)]
        public string menuname { get; set; }

        [StringLength(20)]
        public string linktext { get; set; }

        [StringLength(250)]
        public string linkurl { get; set; }

        [StringLength(10)]
        public string target { get; set; }

        public int? listorder { get; set; }

        [StringLength(10)]
        public string cname { get; set; }

        public int? parentid { get; set; }
    }
}
