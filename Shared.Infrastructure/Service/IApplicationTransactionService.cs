#region

using Shared.Infrastructure.Dto;
using Shared.Infrastructure.Transaction;

#endregion

namespace Shared.Infrastructure.Service
{
    public interface IApplicationTransactionService<TDetail, TEdit>
    {
       
        SaveResponse<TDetail> Save(SaveRequest<TEdit> saveRequest);
        void Delete(UidRequest deleteRequest);
    }
}