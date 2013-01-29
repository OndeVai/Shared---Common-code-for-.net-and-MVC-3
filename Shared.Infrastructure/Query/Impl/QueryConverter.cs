#region

using System.Linq;
using Shared.Domain.Repository;
using Shared.Infrastructure.Conversion;
using Shared.Infrastructure.Dto;

#endregion

namespace Shared.Infrastructure.Query.Impl
{
    public class DtoQueryResultsConverter<TDtoSummary, TDtoDetail, TDomain, TSortBy, TRepository> :
        IQueryResultsConverter<TDtoSummary, TDtoDetail, TDomain, TSortBy>
        where TDomain : class
        where TDtoSummary : class
        where TDtoDetail : class
        where TRepository : IEntityRepository<TDomain>
    {
        private readonly TRepository _repository;
        private readonly ITypeConverter<TDtoSummary, TDtoDetail, TDomain> _typeConverter;

        public DtoQueryResultsConverter(TRepository repository,
                                        ITypeConverter<TDtoSummary, TDtoDetail, TDomain> typeConverter)
        {
            _typeConverter = typeConverter;
            _repository = repository;
        }

        public PagedListResponse<TDtoSummary> ToList(PagingListRequest<TSortBy> listRequest,
                                                     IQuery<TDomain, TSortBy> query)
        {
            var list = query.Execute(listRequest).ToList();
            var convertedList = _typeConverter.ToDtos(list);
            return new PagedListResponse<TDtoSummary>(convertedList, listRequest.Paging);
        }

        public TDtoDetail ToDetail(UidRequest uidFindRequest)
        {
            var find = _repository.Find(uidFindRequest.Id);
            if (find == null) return null;

            return _typeConverter.ToDto(find);
        }
    }
}