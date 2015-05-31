namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ST_MeterProdInfo
    {
        [Key]
        [StringLength(12)]
        public string F_MeterProdID { get; set; }

        [Required]
        [StringLength(48)]
        public string F_MeterProdName { get; set; }

        [Required]
        [StringLength(1)]
        public string F_MaterType { get; set; }

        [StringLength(48)]
        public string F_MeterProducer { get; set; }

        [StringLength(48)]
        public string F_MaterModel { get; set; }

        [StringLength(160)]
        public string F_MeterProdDesc { get; set; }
    }
}
