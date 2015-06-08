namespace EDMWebsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("edm2db.tb_layer")]
    public partial class tb_layer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? imgwidth { get; set; }

        public int? imgheight { get; set; }

        [StringLength(50)]
        public string imgurl { get; set; }
    }
}
