using System.Linq;
using Shared.Application.Infrastructure.Querying.Dto;

namespace Shared.Application.Infrastructure.Querying
{
    public interface IPagedQueryGenerator<TModel, in TSortBy>
    {


        IQueryable<TModel> CreateQueryFor(IQueryable<TModel> baseQuery, IPagingListRequest<TSortBy> pagingListRequest);
    }
}