using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GradinBookWebApp.Startup))]
namespace GradinBookWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
