namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_About
    {
        [Key]
        public int aid { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string style { get; set; }

        [StringLength(250)]
        public string excerpt { get; set; }

        [StringLength(200)]
        public string thumb { get; set; }

        public bool? islink { get; set; }

        [StringLength(200)]
        public string linkurl { get; set; }

        [StringLength(80)]
        public string tags { get; set; }

        [StringLength(100)]
        public string template { get; set; }

        [StringLength(100)]
        public string urlrule { get; set; }

        public int? cateid { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }

        [StringLength(50)]
        public string keywords { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        public int? listorder { get; set; }

        public DateTime? addtime { get; set; }
    }
}
