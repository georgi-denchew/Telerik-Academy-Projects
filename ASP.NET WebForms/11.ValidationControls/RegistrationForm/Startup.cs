using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegistrationForm.Startup))]
namespace RegistrationForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
