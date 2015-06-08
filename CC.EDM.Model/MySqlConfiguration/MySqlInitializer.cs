
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Diagnostics.Contracts;
using System.Linq;
using EDMWebsite.Models;

namespace EDMWebsite
{
    public class MySqlInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public string TableSchema { get; set; }

        public MySqlInitializer(string schema)
        {
            TableSchema = schema;
        }

        public void InitializeDatabase(TContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {
                //// query to check if MigrationHistory table is present in the database 
                //var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                //string.Format(
                //  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                //  TableSchema));//"edm2db"));

                //// if MigrationHistory table is not there (which is the case first time we run) - create it
                //if (migrationHistoryTableExists.FirstOrDefault() == 0)
                //{
                //    context.Database.Delete();
                //    context.Database.Create();
                //}
            }
        }
    }

    public class CreateAndMigrateDatabaseInitializer<TContext, TConfiguration> : CreateDatabaseIfNotExists<TContext>, IDatabaseInitializer<TContext>
        where TContext : DbContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration _configuration;
        public CreateAndMigrateDatabaseInitializer()
        {
            _configuration = new TConfiguration();
        }
        public CreateAndMigrateDatabaseInitializer(string connection)
        {
            Contract.Requires(!string.IsNullOrEmpty(connection), "connection");

            _configuration = new TConfiguration
            {
                TargetDatabase = new DbConnectionInfo(connection)
            };
        }
        void IDatabaseInitializer<TContext>.InitializeDatabase(TContext context)
        {
            Contract.Requires(context != null, "context");

            var migrator = new DbMigrator(_configuration);
            //migrator.Update();
            //migrator.
            if (!context.Database.CompatibleWithModel(throwIfNoMetadata: false))
                if (migrator.GetPendingMigrations().Any())
                    migrator.Update();


            // move on with the 'CreateDatabaseIfNotExists' for the 'Seed'
            base.InitializeDatabase(context);
        }
        protected override void Seed(TContext context)
        {
        }
    }


    //public class MySqlInitializerToWriteableDbContext : IDatabaseInitializer<WriteableMySqlDbContext>
    //{
    //    public void InitializeDatabase(WriteableMySqlDbContext context)
    //    {
    //        if (!context.Database.Exists())
    //        {
    //            // if database did not exist before - create it
    //            context.Database.Create();
    //        }
    //        else
    //        {
    //            // query to check if MigrationHistory table is present in the database 
    //            var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
    //            string.Format(
    //              "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
    //              "mydb"));

    //            // if MigrationHistory table is not there (which is the case first time we run) - create it
    //            if (migrationHistoryTableExists.FirstOrDefault() == 0)
    //            {
    //                context.Database.Delete();
    //                context.Database.Create();
    //            }
    //        }
    //    }
    //}


}