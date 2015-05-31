namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_BuildAddFile
    {
        [Key]
        [StringLength(14)]
        public string F_FileID { get; set; }

        [Required]
        [StringLength(13)]
        public string F_BuildID { get; set; }

        [Required]
        [StringLength(1)]
        public string F_FileFuncType { get; set; }

        [Required]
        [StringLength(1)]
        public string F_FileFormatType { get; set; }

        [StringLength(80)]
        public string F_FileDesc { get; set; }

        public int F_FileSize { get; set; }

        public DateTime F_FileDate { get; set; }

        [Required]
        [StringLength(160)]
        public string F_FilePath { get; set; }

        public virtual T_BD_BuildBaseInfo T_BD_BuildBaseInfo { get; set; }
    }
}
