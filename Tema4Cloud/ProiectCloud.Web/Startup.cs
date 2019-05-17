using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProiectCloud.Web.Startup))]
namespace ProiectCloud.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
