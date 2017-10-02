using System.Reflection;

namespace UnderTheCork.Web.App_Start
{
    public class AutomapperConfig
    {
        public static void Register()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(Assembly.GetExecutingAssembly());
        }
    }
}