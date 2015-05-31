namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_School
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public decimal? Area { get; set; }

        public decimal? CoolArea { get; set; }

        public decimal? HotArea { get; set; }

        public int? Person { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public string Intro { get; set; }

        [StringLength(6)]
        public string ZIPCode { get; set; }

        public DateTime? AddTime { get; set; }

        public int? BuildCount { get; set; }
    }
}
