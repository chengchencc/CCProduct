using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EDMWebsite.Models.DbModels;


namespace EDMWebsite
{
    public class ReadOnlyMySqlDbContext:DbContext
    {
        public ReadOnlyMySqlDbContext()
            : base("AccountDb")
        {
        }
        static ReadOnlyMySqlDbContext()
        {
            Database.SetInitializer<ReadOnlyMySqlDbContext>(null);
        }

        public DbSet<DbFirstTest> DbFirstTestTables { get; set; }

    }

    

}