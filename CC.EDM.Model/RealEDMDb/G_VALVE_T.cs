namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_VALVE_T
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string GCODE { get; set; }

        [StringLength(50)]
        public string GTYPE { get; set; }

        [StringLength(100)]
        public string POSITION { get; set; }

        [StringLength(200)]
        public string LX { get; set; }

        [StringLength(200)]
        public string GMODEL { get; set; }

        [Column(TypeName = "image")]
        public byte[] ACCESSORY { get; set; }
    }
}
