using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using UnderTheCork.Web.App_Start;

namespace UnderTheCork.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            UnderTheCorkSqlDbConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutomapperConfig.Register();
        }
    }
}
