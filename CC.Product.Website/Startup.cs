using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CC.Product.Website.Startup))]
namespace CC.Product.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
