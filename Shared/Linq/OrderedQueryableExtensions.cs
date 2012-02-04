#region

using System.Linq;

#endregion

namespace Shared.Linq
{
    public static class OrderedQueryableExtensions
    {
        public static IQueryable<TEntity> PageThis<TEntity>(this IQueryable<TEntity> queryable, int pageNumber, int pageSize)
        {
            return queryable
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        public static IQueryable<TEntity> Page<TEntity>(this IOrderedQueryable<TEntity> queryable, int pageNumber, int pageSize)
        {
            return queryable
                .Skip(pageSize * (pageNumber-1))
                .Take(pageSize);
        }
    }
}