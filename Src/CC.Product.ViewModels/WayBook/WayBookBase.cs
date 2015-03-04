using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Product.ViewModels
{
    public class WayBookBase<T> where T:new()
    {
        public Status status { get; set; }
        public List<T> result { get; set; }
    }
}