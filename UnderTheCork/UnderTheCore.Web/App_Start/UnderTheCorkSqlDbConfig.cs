using System.Data.Entity;

using UnderTheCork.Data;
using UnderTheCork.Data.Migrations;

namespace UnderTheCore.Web.App_Start
{
    public class UnderTheCorkSqlDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UnderTheCorkSqlDbContext, Configuration>());
        }
    }
}