#region

using System.Linq;

#endregion

namespace Shared.Linq
{
    public static class LinqExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int index, int size)
        {
            return queryable.Skip((index - 1)*size).Take(size);
        }
    }
}