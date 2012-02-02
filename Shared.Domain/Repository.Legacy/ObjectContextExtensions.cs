#region

using System;
using System.Data;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

#endregion

namespace FreshExpress.Gain.Domain.Repositories.Impl.Base
{
    public static class ObjectContextExtensions
    {
        internal static EntitySetBase GetEntitySet<TEntity>(this ObjectContext context)
        {
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            var baseType = GetBaseType(typeof (TEntity));
            var entitySet = container.BaseEntitySets
                .Where(item => item.ElementType.Name.Equals(baseType.Name))
                .FirstOrDefault();

            return entitySet;
        }

        internal static bool IsAttached(this ObjectContext context, EntityKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key");
            }
            ObjectStateEntry entry;
            if (context.ObjectStateManager.TryGetObjectStateEntry(key, out entry))
            {
                return (entry.State != EntityState.Detached);
            }
            return false;
        }


        private static Type GetBaseType(Type type)
        {
            var baseType = type.BaseType;
            if (baseType != null && baseType != typeof (EntityObject))
            {
                return GetBaseType(type.BaseType);
            }
            return type;
        }
    }
}