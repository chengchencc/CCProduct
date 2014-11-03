using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC.Product.Models.CarPooling
{
    public class CarpoolingInfo
    {
        public int Id { get; set; }
        public string No { get; set; }

        [Display(Name = "始发地"),Required]        
        public string StartSite { get; set; }

        [Display(Name = "目的地"),Required]
        public string Destination { get; set; }

        [Display(Name = "出发日期"),Required]
        public DateTime DateTime { get; set; }

        [Display(Name = "创建日期")]
        public DateTime? CreateTime { get; set; }
        public string PublishUserId { get; set; }
        [Display(Name = "座位数")]
        public int TotalSeatCount { get; set; }
        public bool HasCar { get; set; }

        [Display(Name = "价格")]
        public decimal Price { get; set; }

        [Display(Name="联系方式")]
        public virtual List<Contact> Contacts { get; set; }

        [Display(Name = "备注")]
        public string Comment { get; set; }

        public virtual List<TakeIn> TakeIns { get; set; }

        [Display(Name = "途经地")]
        public string PassingBySite { get; set; }
        public virtual List<Tag> Tags { get; set; }

    }
}