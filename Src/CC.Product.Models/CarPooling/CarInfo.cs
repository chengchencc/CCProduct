using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CC.Product.Models.CarPooling
{
    public class CarInfo
    {
        public int Id { get; set; }

        [Display(Name = "车型")]
        public CarType CarType{ get; set; }

        [Display(Name = "车牌号")]
        public string CarNo { get; set; }

        [Display(Name="型号")]
        public string Name { get; set; }

    }

}