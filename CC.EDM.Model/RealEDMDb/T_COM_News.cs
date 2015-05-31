namespace CC.EDM.Model.RealEDMDb
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_COM_News
    {
        [Key]
        public long nid { get; set; }

        [StringLength(60)]
        public string title { get; set; }

        [StringLength(250)]
        public string excerpt { get; set; }

        public short? cateid { get; set; }

        [StringLength(80)]
        public string tags { get; set; }

        [StringLength(100)]
        public string style { get; set; }

        [StringLength(250)]
        public string thumb { get; set; }

        [StringLength(50)]
        public string keywords { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        public bool? islink { get; set; }

        [StringLength(250)]
        public string linkurl { get; set; }

        public int? listorder { get; set; }

        public DateTime? addtime { get; set; }

        public DateTime? updatetime { get; set; }

        public byte? status { get; set; }

        public bool? sysadd { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }

        public decimal? readpoint { get; set; }

        public short? credit { get; set; }

        [StringLength(100)]
        public string groupids_view { get; set; }

        public bool? allow_comment { get; set; }

        public int? maxcharperpage { get; set; }

        public int? hits { get; set; }

        [StringLength(100)]
        public string template { get; set; }

        [StringLength(250)]
        public string urlrule { get; set; }

        [StringLength(30)]
        public string copyfrom { get; set; }

        [StringLength(100)]
        public string attachmentids { get; set; }

        public short? voteid { get; set; }

        [StringLength(100)]
        public string newsids { get; set; }

        [StringLength(20)]
        public string username { get; set; }

        public int? userid { get; set; }

        public short? good { get; set; }

        public short? bad { get; set; }

        public byte? star { get; set; }
    }
}
