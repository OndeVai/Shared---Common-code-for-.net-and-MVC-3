#region

using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Shared.Domain.Infrastructure;

#endregion

namespace Shared.Domain.Repository.Impl
{
    // ReSharper disable UnusedMember.Global
    public abstract class DbContextGenericRepository<TDBContext, TModel> :
        // ReSharper restore UnusedMember.Global
        IGenericRepository<TModel>
        where TModel : class
        where TDBContext : DbContext, IUnitOfWork, new()
    {
        private bool _disposed;
        private TDBContext _entities;

        protected DbContextGenericRepository(TDBContext entities)
        {
            _entities = entities;
        }

        // ReSharper disable UnusedMember.Global
        protected TDBContext Context
        // ReSharper restore UnusedMember.Global
        {
            get { return _entities; }
            set { _entities = value; }
        }

        #region IGenericRepository<TModel> Members

        public virtual IQueryable<TModel> GetAll()
        {
            IQueryable<TModel> query = _entities.Set<TModel>();
            return query;
        }

        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            var query = _entities.Set<TModel>().Where(predicate);
            return query;
        }

        public virtual void Add(TModel entity)
        {
            _entities.Set<TModel>().Add(entity);
        }

        public virtual void Delete(TModel entity)
        {
            _entities.Set<TModel>().Remove(entity);
        }

        public virtual void Edit(TModel entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) if (disposing) _entities.Dispose();

            _disposed = true;
        }
    }
}