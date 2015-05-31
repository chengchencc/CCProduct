namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_FLYPOINT_T
    {
        [Key]
        public int POINTID { get; set; }

        public int? POINTORDER { get; set; }

        public double? POSITIONX { get; set; }

        public double? POSITIONY { get; set; }

        public double? POSITIONZ { get; set; }

        public double? TARGETX { get; set; }

        public double? TARGETY { get; set; }

        public double? TARGETZ { get; set; }

        public int? FLYID { get; set; }

        public virtual G_FLYROAD_T G_FLYROAD_T { get; set; }
    }
}
