using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using EDMWebsite.Models.DbModels;


namespace EDMWebsite
{
    [System.Data.Entity.DbConfigurationType(typeof(MySqlConfiguration))]
    public class WriteableMySqlDbContext : DbContext
    {
        public WriteableMySqlDbContext()
            : base("MyDb")
        {
            
        }
        static WriteableMySqlDbContext()
        {
            Database.SetInitializer(new MySqlInitializerToWriteableDbContext());
        }


        public DbSet<Comdict> Comdicts { get; set; }
        

    }

    

}