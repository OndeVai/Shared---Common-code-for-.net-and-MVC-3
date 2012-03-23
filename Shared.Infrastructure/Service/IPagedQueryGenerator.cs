using System.Linq;
using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Service
{
    public interface IPagedQueryGenerator<TModel, in TSortBy>
    {


        IQueryable<TModel> CreateQueryFor(IQueryable<TModel> baseQuery, IPagingListRequest<TSortBy> pagingListRequest);
    }
}