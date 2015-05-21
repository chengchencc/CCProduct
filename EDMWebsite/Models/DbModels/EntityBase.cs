using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    public class EntityBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Display(Name="状态")]
        public EntityStatus Status { get; set; }

        [Display(Name = "创建日期"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "修改日期"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ModifiedDate { get; set; }
    }

    public enum EntityStatus
    {
        Enabled = 1,
        Disabled = 2
    }
}