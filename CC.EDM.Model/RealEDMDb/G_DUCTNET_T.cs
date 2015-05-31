namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_DUCTNET_T
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string GCODE { get; set; }

        [StringLength(50)]
        public string GTYPE { get; set; }

        [StringLength(50)]
        public string PURPOSE { get; set; }

        [StringLength(100)]
        public string STARTPOSITION { get; set; }

        [StringLength(100)]
        public string ENDPOSITION { get; set; }

        [StringLength(100)]
        public string DUCTLENGTH { get; set; }

        [StringLength(100)]
        public string PIPEDIAMETER { get; set; }

        [StringLength(100)]
        public string MATERIALQUALITY { get; set; }

        [StringLength(100)]
        public string BUILDTIME { get; set; }

        [StringLength(100)]
        public string PRINCIPAL { get; set; }

        public DateTime? ENDTIME { get; set; }

        public int? WALLTHICKNESS { get; set; }

        [Column(TypeName = "image")]
        public byte[] ACCESSORY { get; set; }

        [StringLength(100)]
        public string IMAGNAME { get; set; }
    }
}
