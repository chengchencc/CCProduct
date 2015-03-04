using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Product.Website.Models
{
    public class WayBookBase<T> where T:new()
    {
        public string MyProperty { get; set; }
    }



}