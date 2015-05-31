namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_Zhibiao
    {
        public int ID { get; set; }

        public int? SchoolID { get; set; }

        public decimal? AreaWator { get; set; }

        public decimal? AreaDian { get; set; }

        public decimal? AreaEqu { get; set; }

        public decimal? AreaPrice { get; set; }

        public decimal? PeoWator { get; set; }

        public decimal? PeoDian { get; set; }

        public decimal? PeoEqu { get; set; }

        public decimal? PeoPrice { get; set; }
    }
}
