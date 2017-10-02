using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnderTheCork.Web.Startup))]
namespace UnderTheCork.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
