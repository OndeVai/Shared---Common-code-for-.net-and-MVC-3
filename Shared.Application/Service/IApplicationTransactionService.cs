#region

using Shared.Application.Dto;

#endregion

namespace Shared.Application.Service
{
    public interface IApplicationTransactionService<TDetail, TEdit>
    {
        SaveResponse<TDetail> Save(SaveRequest<TEdit> saveRequest);
    }
}