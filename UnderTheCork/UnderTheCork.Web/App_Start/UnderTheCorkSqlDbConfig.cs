using System.Data.Entity;

using UnderTheCork.Data.DbContexts;
using UnderTheCork.Data.Migrations;

namespace UnderTheCork.Web.App_Start
{
    public class UnderTheCorkSqlDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UnderTheCorkSqlDbContext, Configuration>());
        }
    }
}