namespace EDMWebsite.Models.DbModels.ReadOnly
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_BD_BuildGroupBaseInfo
    {
        public T_BD_BuildGroupBaseInfo()
        {
            T_BD_BuildBaseInfo = new HashSet<T_BD_BuildBaseInfo>();
        }

        [Key]
        [StringLength(10)]
        public string F_BuildGroupID { get; set; }

        [StringLength(48)]
        public string F_BuildGroupName { get; set; }

        [StringLength(16)]
        public string F_GroupAliasName { get; set; }

        [Required]
        [StringLength(800)]
        public string F_GroupDesc { get; set; }

        public virtual ICollection<T_BD_BuildBaseInfo> T_BD_BuildBaseInfo { get; set; }
    }
}
