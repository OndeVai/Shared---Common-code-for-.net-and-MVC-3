using System.Linq;
using Shared.Infrastructure.Querying.Dto;

namespace Shared.Infrastructure.Querying
{
    public interface IPagedQueryGenerator<TModel, in TSortBy>
    {


        IQueryable<TModel> CreateQueryFor(IQueryable<TModel> baseQuery, IPagingListRequest<TSortBy> pagingListRequest);
    }
}