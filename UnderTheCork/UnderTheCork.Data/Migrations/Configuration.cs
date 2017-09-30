using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using UnderTheCork.Data.Models;

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
    }
}
