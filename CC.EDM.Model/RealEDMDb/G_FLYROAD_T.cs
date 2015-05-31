namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_FLYROAD_T
    {
        public G_FLYROAD_T()
        {
            G_FLYPOINT_T = new HashSet<G_FLYPOINT_T>();
        }

        [StringLength(50)]
        public string FLYNAME { get; set; }

        [Key]
        public int FLYID { get; set; }

        public virtual ICollection<G_FLYPOINT_T> G_FLYPOINT_T { get; set; }

        public virtual G_FLYROAD_T G_FLYROAD_T1 { get; set; }

        public virtual G_FLYROAD_T G_FLYROAD_T2 { get; set; }
    }
}
