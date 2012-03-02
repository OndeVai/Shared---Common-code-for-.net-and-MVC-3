using System.Linq;

namespace Shared.Application.Infrastructure.Querying
{
    public interface IQuerySortFactory<TModel, in TSortBy>
    {
        IQueryable<TModel> SortQueryFor(IQueryable<TModel> baseQuery, TSortBy sortBy, bool orderByDescending);
    }
}