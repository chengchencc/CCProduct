using CC.Product.Domain.DI;
using Microsoft.Owin;
using Owin;
using CC.Product.Data.Contexts;
using System.Data.Entity;
[assembly: OwinStartupAttribute(typeof(CC.Product.Website.Startup))]
namespace CC.Product.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //System.Data.Entity.Database.SetInitializer<LocalDBContext>(null );
            //Database.SetInitializer<LocalDBContext>(null);
            //Database.SetInitializer(new CreateDatabaseIfNotExists<LocalDBContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<LocalDBContext>());
            Database.SetInitializer<LocalDBContext>(new DropCreateDatabaseIfModelChanges<LocalDBContext>());
            ConfigureAuth(app);
        }
    }
}
