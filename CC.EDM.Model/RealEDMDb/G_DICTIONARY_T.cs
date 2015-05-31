namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class G_DICTIONARY_T
    {
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string TABLENAME { get; set; }

        [Required]
        [StringLength(20)]
        public string COLUMNNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string ANOTHERNAME { get; set; }
    }
}
