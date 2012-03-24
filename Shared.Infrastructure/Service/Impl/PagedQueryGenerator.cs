#region

using System.Linq;
using Shared.Infrastructure.Dto;
using Shared.Infrastructure.Navigation.Helpers;
using Shared.Linq;

#endregion

namespace Shared.Infrastructure.Service.Impl
{
    public class SortedPagedQueryGenerator<TModel, TSortBy> : IPagedQueryGenerator<TModel, TSortBy>
    {
        private readonly IQuerySortFactory<TModel, TSortBy> _querySortFactory;

        public SortedPagedQueryGenerator(IQuerySortFactory<TModel, TSortBy> querySortFactory)
        {
            _querySortFactory = querySortFactory;
        }

        public virtual IQueryable<TModel> CreateQueryFor(IQueryable<TModel> baseQuery, IPagingListRequest<TSortBy> pagingListRequest)
        {
            var queryCount = baseQuery.Count();
            var adjustedPaging = pagingListRequest.Paging;
            adjustedPaging.AdjustForCountOf(queryCount);
            return _querySortFactory.SortQueryFor(baseQuery, pagingListRequest.SortBy, pagingListRequest.OrderByDescending)
                   .Page(adjustedPaging.CurrentPage, adjustedPaging.ItemsPerPage);
        }
    }
}