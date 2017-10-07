using System;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

using UnderTheCork.Data.Models;
using UnderTheCork.Data.Models.Contracts;

namespace UnderTheCork.Data.DbContexts
{
    public class UnderTheCorkSqlDbContext : IdentityDbContext<User>, IUnderTheCorkSqlDbContext
    {
        public UnderTheCorkSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Region> Regions { get; set; }

        public IDbSet<Winery> Wineries { get; set; }

        public IDbSet<Wine> Wines { get; set; }

        public IDbSet<WineReview> WineReviews { get; set; }

        public IDbSet<ReviewComment> ReviewComments { get; set; }

        public IDbSet<WineImage> WineImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Wine>()
                .HasOptional(i => i.WineImage)
                .WithRequired(w => w.Wine);
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
