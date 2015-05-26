using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EDMWebsite.Models.DbModels;


namespace EDMWebsite
{
    public class ReadOnlySqlDbContext:DbContext
    {
        public ReadOnlySqlDbContext()
            : base("RealDb")
        {
        }
        static ReadOnlySqlDbContext()
        {
            Database.SetInitializer<ReadOnlySqlDbContext>(null);
        }


    }

    

}