using System.Data.Entity;
using Shared.Domain.Infrastructure;

namespace Shared.Domain.Repository.Impl
{
    public abstract class EntityDBContextGenericRepository<TDBContext, TModel> : DbContextGenericRepository<TDBContext, TModel>
        where TModel : EntityBase, IAggregateRoot, new()
        where TDBContext : DbContext, IUnitOfWork
    {
        protected EntityDBContextGenericRepository(TDBContext entities)
            : base(entities)
        {
        }

        //public override void MarkForSave(TModel model)
        //{
        //    if (model.Id > 0)
        //        Edit(model);
        //    else
        //        Add(model);
        //}
    }
}