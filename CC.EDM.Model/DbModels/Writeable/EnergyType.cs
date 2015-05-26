
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EDMWebsite.Models.DbModels
{
    public partial class EnergyType
    {
        public EnergyType()
        {

        }

        [Key]
        [StringLength(5)]
        [Display(Name = "编号")]
        public string F_EnergyItemCode { get; set; }

        [Required]
        [StringLength(32)]
        [Display(Name = "名称")]
        public string F_EnergyItemName { get; set; }

        [StringLength(16)]
        [Display(Name = "父节点编号")]
        public string F_ParentItemCode { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "能耗类型")]
        public string F_EnergyItemType { get; set; }

        [Required]
        [StringLength(16)]
        [Display(Name = "单位")]
        public string F_EnergyItemUnit { get; set; }

        [Required]
        [StringLength(16)]
        [Display(Name = "换算公式")]
        public string F_EnergyItemFml { get; set; }

        [Display(Name = "启动状态")]
        public short F_EnergyItemState { get; set; }

        public virtual List<Room> Rooms { get; set; }

    }
}
