using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using EDMWebsite.Migrations;
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
            //Database.SetInitializer<WriteableSqlDbContext>(new DropCreateDatabaseIfModelChanges<WriteableSqlDbContext>());
            Database.SetInitializer<WriteableSqlDbContext>(new MigrateDatabaseToLatestVersion<WriteableSqlDbContext, Configuration>());
        }

        public DbSet<DbFirstTest> DbFirstTestTables { get; set; }
        public DbSet<Comdict> Comdicts { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Institute> Institutes { get; set; }

    }

    

}