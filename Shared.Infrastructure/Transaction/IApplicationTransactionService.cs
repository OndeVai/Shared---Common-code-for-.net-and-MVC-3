#region

using Shared.Infrastructure.Dto;

#endregion

namespace Shared.Infrastructure.Transaction
{
    public interface IApplicationTransactionService<TDetail, TEdit>
    {
        SaveResponse<TDetail> Save(SaveRequest<TEdit> saveRequest);
    }
}