using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UnderTheCork.Data.DbContexts
{
    public interface IUnderTheCorkSqlDbContext
    {
        DbSet<TEntity> Set<TEntity>()
            where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity)
            where TEntity : class;

        int SaveChanges();
    }
}
