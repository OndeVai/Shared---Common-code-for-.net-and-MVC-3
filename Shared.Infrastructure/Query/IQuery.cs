using System.Collections.Generic;
using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Query
{
    public interface IQuery<out TResult, TSortBy>
    {

        IEnumerable<TResult> Execute(PagingListRequest<TSortBy> listRequest);
    }
}