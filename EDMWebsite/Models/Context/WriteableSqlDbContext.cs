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
    public class WriteableSqlDbContext : DbContext
    {
        public WriteableSqlDbContext()
            : base("RealDb")
        {
            
        }
        static WriteableSqlDbContext()
        {
            //Database.SetInitializer( );
        }

        public DbSet<DbFirstTest> DbFirstTestTables { get; set; }

        public DbSet<Comdict> Comdicts { get; set; }
        

    }

    

}