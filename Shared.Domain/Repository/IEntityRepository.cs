#region

using System.Linq;

#endregion

namespace Shared.Domain.Repository
{
    public interface IEntityRepository<T>
    {
        int GetCount();
        IQueryable<T> GetAll();
        T Find(int id);
        void Save(T entity);
        void Delete(T entity);
    }
}