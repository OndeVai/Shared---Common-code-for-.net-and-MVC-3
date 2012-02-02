#region

using System.Linq;

#endregion

namespace Shared.Data.Linq
{
    // ReSharper disable UnusedMember.Global
    public static class QueryExtensions
    // ReSharper restore UnusedMember.Global
    {
        // ReSharper disable UnusedMember.Global
        public static IQueryable<TEntity> Page<TEntity>(this IOrderedQueryable<TEntity> queryable, int pageNumber, int pageSize)
        // ReSharper restore UnusedMember.Global
        {
            return queryable
                .Skip(pageSize * pageNumber)
                .Take(pageSize);
        }
    }
}