using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SitePerso.Startup))]
namespace SitePerso
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
