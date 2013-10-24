using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoListWebApplication.Startup))]
namespace TodoListWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
