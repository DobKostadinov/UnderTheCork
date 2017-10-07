using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json.Linq;

using UnderTheCork.Data.Models;
using UnderTheCork.Data.DbContexts;

namespace UnderTheCork.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<UnderTheCorkSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UnderTheCorkSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.ImportCountriesAndRegions(context);
        }

        private void SeedAdmin(UnderTheCorkSqlDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = "123456";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }

        private void ImportCountriesAndRegions(UnderTheCorkSqlDbContext context)
        {
            if (!context.Countries.Any())
            {
                using (WebClient client = new WebClient())
                {
                    string countriesAndRegions = client.DownloadString("https://api.myjson.com/bins/1ea8vh");

                    JArray allCountries = JArray.Parse(countriesAndRegions);

                    foreach (var country in allCountries)
                    {
                        var countryName = country["Country"].ToString();
                        var newCountry = new Country
                        {
                            Name = countryName
                        };

                        context.Countries.AddOrUpdate(newCountry);
                        context.SaveChanges();

                        var crrCountry = context.Countries.First(x => x.Name == countryName);

                        var regions = country["Regions"];

                        foreach (var region in regions)
                        {
                            var regionName = region.ToString();
                            var newRegion = new Region
                            {
                                Name = regionName,
                                CountryId = crrCountry.Id,
                                Country = crrCountry
                            };
                            context.Regions.AddOrUpdate(newRegion);
                            context.SaveChanges();
                        }
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
