using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EDMWebsite.Models.DbModels
{
    //[Table("DbFirstTest")]
    public class Room : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public RoomType Type { get; set; }
        public decimal Area { get; set; }

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