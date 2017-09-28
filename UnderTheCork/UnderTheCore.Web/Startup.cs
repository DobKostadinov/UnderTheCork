using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnderTheCore.Web.Startup))]
namespace UnderTheCore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
