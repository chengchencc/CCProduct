using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Product.Models.CarPooling
{
    public class TakeIn
    {
        public int Id { get; set; }
        public int CarpoolingId { get; set; }
        public string UserId { get; set; }
        public int Count { get; set; }
        public string Comment { get; set; }
        public virtual CarpoolingInfo Carpooling { get; set; }
    }
}