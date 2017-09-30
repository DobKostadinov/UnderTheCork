using System.Linq;

namespace UnderTheCork.Data.Repositories
{
    public interface IEfRepostory<T>
    where T : class
    {
        IQueryable<T> All { get; }

        IQueryable<T> AllAndDeleted { get; }

        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);
    }
}
