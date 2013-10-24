using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteNavigation.Startup))]
namespace SiteNavigation
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
