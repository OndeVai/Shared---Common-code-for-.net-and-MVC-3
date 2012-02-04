using System;
using System.Linq;
using System.Linq.Expressions;
using Shared.Domain.Infrastructure;

namespace Shared.Domain.Repository {

    public interface IGenericRepository<TModel> : IDisposable where TModel : class, IAggregateRoot
    {

        int GetCount();
        IQueryable<TModel> GetAll();
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        void Add(TModel entity);
        void Delete(TModel entity);
        void Edit(TModel entity);
        IQueryable<TModel> GetAll<TValue>(Expression<Func<TModel, TValue>> orderBy, int pageNumber, int pageSize);
        void MarkForSave(TModel model);
    }
}