#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Shared.Application.Query
{
    public interface IQuery<in TSource, out TResult>
    {
        IEnumerable<TResult> Execute(IQueryable<TSource> source);
    }
}