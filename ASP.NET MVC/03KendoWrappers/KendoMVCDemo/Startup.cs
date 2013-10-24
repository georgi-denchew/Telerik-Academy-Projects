using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoMVCDemo.Startup))]
namespace KendoMVCDemo
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
