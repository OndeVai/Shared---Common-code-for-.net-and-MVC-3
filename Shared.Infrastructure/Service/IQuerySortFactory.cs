using System.Linq;

namespace Shared.Infrastructure.Service
{
    public interface IQuerySortFactory<TModel, in TSortBy>
    {
        IQueryable<TModel> SortQueryFor(IQueryable<TModel> baseQuery, TSortBy sortBy, bool orderByDescending);
    }
}