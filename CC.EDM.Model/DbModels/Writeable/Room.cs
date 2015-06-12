using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Room : EntityBase
    {
        [Display(Name="编号")]
        //[Index(IsUnique=true)]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "房屋类型")]
        public RoomType Type { get; set; }

        [Display(Name = "房间面积")]
        public decimal Area { get; set; }

        [Display(Name="所属建筑")]
        [Column("Building_Id")]
        public int BuildingId { get; set; }

        [Display(Name="所属学院")]
        [Column("Institute_Id")]
        public int InstituteId { get; set; }

        //[ForeignKey("Building_Id")]
        //[InverseProperty("Rooms")]
        public virtual Building Building { get; set; }

        public virtual Institute Institute { get; set; }

        public virtual UnitPrice UnitPrice { get; set; }

        public virtual List<RoomHosts> Hosts { get; set; }

    }

    public enum RoomType
    {
        办公室,
        学生宿舍,
        小型教室,
        中型教室,
        大型教室,
        计算机教室,
        科学实验室,
        音乐教室,
        美术教室,
        卫生保健室,
        会议接待时,
        档案室,
        行政办公室,
        教师办公室,
        图书馆,
        小型会议室,
        中型会议室,
        大型会议室,
        厕所,
        其它
    }

}