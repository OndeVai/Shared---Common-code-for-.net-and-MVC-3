#region



#endregion

using Shared.Infrastructure.Dto;

namespace Shared.Infrastructure.Transaction
{
    public interface IApplicationTransactionService<TDetail, TEdit>
    {
       
        SaveResponse<TDetail> Save(SaveRequest<TEdit> saveRequest);
    }
}