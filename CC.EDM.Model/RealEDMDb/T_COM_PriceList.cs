namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_PriceList
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        public DateTime? AddTime { get; set; }

        public decimal? Electrovalence { get; set; }

        public decimal? WaterPrice { get; set; }

        public decimal? GasPrice { get; set; }

        public decimal? SteamPrice { get; set; }

        public decimal? CoalPrice { get; set; }
    }
}
