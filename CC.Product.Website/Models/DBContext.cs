using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CC.Product.Models.CarPooling;

namespace CC.Product.Website
{
    public class DBContext:DbContext
    {
        public DBContext()
            : base("MyDB")
        {
        }
        public virtual DbSet<CarInfo> CarInfos { get; set; }
        public virtual DbSet<CarpoolingInfo> CarpoolingInfos { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TakeIn> TakeIns { get; set; }
        
    }
}