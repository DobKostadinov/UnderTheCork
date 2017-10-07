using UnderTheCork.Data.DbContexts;

namespace UnderTheCork.Data.UnitOfWork
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        private readonly UnderTheCorkSqlDbContext context;

        public EfUnitOfWork(UnderTheCorkSqlDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
