using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_06.WebCounterDatabase.Startup))]
namespace _06.WebCounterDatabase
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
