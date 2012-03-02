using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shared.Application.Infrastructure.Querying
{
    public abstract class QuerySortFactory<TModel, TSortBy> : IQuerySortFactory<TModel, TSortBy>
    {
        public abstract IQueryable<TModel> SortQueryFor(IQueryable<TModel> baseQuery, TSortBy sortBy, bool orderByDescending);


        protected IOrderedQueryable<TModel> OrderBy<TValue>(IQueryable<TModel> baseQuery, Expression<Func<TModel, TValue>> predicate, 
                                                            bool orderByDescending)
        {
            return orderByDescending ? baseQuery.OrderByDescending(predicate) : baseQuery.OrderBy(predicate);
        }
    }
}