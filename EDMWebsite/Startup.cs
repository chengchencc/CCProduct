using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EDMWebsite.Startup))]
namespace EDMWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
