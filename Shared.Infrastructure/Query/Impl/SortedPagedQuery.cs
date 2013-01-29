#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Shared.Infrastructure.Dto;
using Shared.Linq;

#endregion

namespace Shared.Infrastructure.Query.Impl
{
    //todo decorator pattern paged(sorted(base))
    public abstract class SortedPagedQuery<TResult, TSortBy> : IQuery<TResult, TSortBy>
    {
        public IEnumerable<TResult> Execute(PagingListRequest<TSortBy> pagingListRequest)
        {
            var baseQuery = Expression();
            var queryCount = baseQuery.Count();
            var adjustedPaging = pagingListRequest.Paging;
            adjustedPaging.BuildActuals(queryCount);
            return Sort(baseQuery, pagingListRequest.SortBy, pagingListRequest.OrderByDescending)
                .Page(adjustedPaging.CurrentPage, adjustedPaging.ItemsPerPage);
        }

        protected IOrderedQueryable<TResult> OrderBy<TValue>(IQueryable<TResult> baseQuery,
                                                             Expression<Func<TResult, TValue>> predicate,
                                                             bool orderByDescending)
        {
            return orderByDescending ? baseQuery.OrderByDescending(predicate) : baseQuery.OrderBy(predicate);
        }

        protected abstract IQueryable<TResult> Expression();

        protected abstract IQueryable<TResult> Sort(IQueryable<TResult> baseQuery, TSortBy sortBy,
                                                    bool orderByDescending);
    }
}