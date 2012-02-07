using System.Data.Entity;
using System.Linq;
using Shared.Domain.Infrastructure;

namespace Shared.Domain.Repository.Impl
{
    public abstract class EntityDBContextGenericRepository<TDBContext, TModel> : DbContextGenericRepository<TDBContext, TModel>
        where TModel : EntityBase<int>, IAggregateRoot, new()
        where TDBContext : DbContext, IUnitOfWork
    {
        protected EntityDBContextGenericRepository(TDBContext entities)
            : base(entities)
        {
        }

        public virtual TModel Find(int id)
        {
            return FindBy(e => e.Id == id).FirstOrDefault();
        }

        public override void MarkForSave(TModel model)
        {
            if (model.Id > 0)
                Edit(model);
            else
                Add(model);
        }
    }
}