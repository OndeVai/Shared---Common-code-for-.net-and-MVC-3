#region

using System;
using System.Data;
using System.Data.Objects;

#endregion

namespace Shared.Domain.Repository.Legacy
{
    public abstract class BaseObjectContextRepository<T,TContext> : IContextLifetimeManager where TContext : ObjectContext where T : class
    {

        protected abstract TContext CreateContext();
        

        protected void Update(T entity, ObjectContext context)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            var key = context.CreateEntityKey(context.GetEntitySet<T>().Name, entity);
            if (context.IsAttached(key))
            {
                context.ApplyCurrentValues(key.EntitySetName, entity);
            }
            else
            {
                context.AttachTo(context.GetEntitySet<T>().Name, entity);
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            }
            context.SaveChanges();
        }

        protected void Add(T entity, ObjectContext context)
        {
            context.AddObject(context.GetEntitySet<T>().Name, entity);
            context.SaveChanges();
        }

        #region Implementation of IContextLifetimeManager

        public bool KeepContextAlive { get; set; }

        #endregion

       
    }
}