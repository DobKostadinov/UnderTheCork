using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using UnderTheCork.Data.Models;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data
{
    public class UnderTheCorkSqlDbContext : IdentityDbContext<User>
    {
        public UnderTheCorkSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static UnderTheCorkSqlDbContext Create()
        {
            return new UnderTheCorkSqlDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
