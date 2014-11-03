using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackMamba.Framework.SubSonic;
using SubSonic.SqlGeneration.Schema;

namespace CC.Product.Models.CarPooling
{
    public class MainBusiness :EntityBase
    {
        [Display(Name = "始发地")]
        public string DepartPosition { get; set; }

        [Display(Name = "目的地")]
        public string Destination { get; set; }

        [Display(Name="所属区域")]
        public string Region { get; set; }

        [Display(Name="出发日期")]
        public DateTime DepartTime { get; set; }

        [Display(Name="总座位数")]
        public int TotalSeatCount { get; set; }

        [Display(Name = "剩余座位数")]
        public int AvailableSeatCount { get; set; }

        [Display(Name="价格")]
        public decimal Price { get; set; }

        [Display(Name="备注")]
        [SubSonicNullString]
        public string Comment { get; set; }

        [Display(Name = "拼车类型")]
        public CarPoolingType CarPoolingType { get; set; }

        [Display(Name = "备注")]
        public CarType CarType { get; set; }

        [Display(Name = "联系QQ")]
        [SubSonicNullString]
        public string QQ { get; set; }
        
        [Display(Name = "联系电话")]
        [SubSonicNullString]
        public string PhoneNumber { get; set; }

        [Display(Name = "用户ID")]
        public string UserId { get; set; }

        [Display(Name = "路线")]
        [SubSonicNullString]
        public string Route { get; set; }


    }
}
