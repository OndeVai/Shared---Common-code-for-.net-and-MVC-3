#region

using System.Linq;

#endregion

namespace Shared.Application.Query
{
    public interface IQuery<in TSource, out TResult>
    {
        IQueryable<TResult> Execute(IQueryable<TSource> source);
    }
}