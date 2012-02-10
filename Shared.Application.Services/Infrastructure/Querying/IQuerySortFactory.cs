using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Application.Infrastructure.Querying
{
    public interface IQuerySortFactory<TModel, in TSortBy>
    {
        IQueryable<TModel> SortQueryFor(IQueryable<TModel> baseQuery, TSortBy sortBy, bool orderByDescending);
    }

    public abstract class QuerySortFactory<TModel, TSortBy> : IQuerySortFactory<TModel, TSortBy>
    {
        public abstract IQueryable<TModel> SortQueryFor(IQueryable<TModel> baseQuery, TSortBy sortBy, bool orderByDescending);


        protected IOrderedQueryable<TModel> OrderBy<TValue>(IQueryable<TModel> baseQuery, Expression<Func<TModel,TValue>> predicate, bool orderByDescending)
        {
            return (IOrderedQueryable<TModel>) (orderByDescending ? baseQuery.OrderByDescending(predicate) : baseQuery.OrderBy(predicate));
        }
    }
}