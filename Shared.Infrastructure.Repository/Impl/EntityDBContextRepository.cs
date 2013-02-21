#region

using System.Data.Entity;
using System.Linq;
using Shared.Domain.Logic;

#endregion

namespace Shared.Infrastructure.Repository.Impl
{
    public abstract class EntityDBContextRepository<TDBContext, TModel> : DbContextRepository<TDBContext, TModel>
        where TModel : RulesEntityBase<int>, IAggregateRoot, new()
        where TDBContext : DbContext, IUnitOfWork
    {
        protected EntityDBContextRepository(TDBContext entities)
            : base(entities)
        {
        }

        public virtual TModel Find(int id)
        {
            return FindBy(e => e.Id == id).FirstOrDefault();
        }

        public override void Save(TModel model)
        {
            if (model.Id > 0)
                Edit(model);
            else
                Add(model);
        }
    }
}