namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_PosMap
    {
        public int id { get; set; }

        [StringLength(20)]
        public string sbid { get; set; }

        public int? x { get; set; }

        public int? y { get; set; }

        [StringLength(20)]
        public string postype { get; set; }

        [StringLength(250)]
        public string sqlstr { get; set; }

        [StringLength(250)]
        public string sqlstr2 { get; set; }

        public int? picwidth { get; set; }

        public int? picheight { get; set; }

        public int? poswidth { get; set; }

        public int? posheight { get; set; }
    }
}
