#region

using System.Collections.Generic;

#endregion

namespace Shared.Application.Conversion
{
    public interface ITypeConverter<TDtoSummary, TDtoDetail, TModel>
    {
        TDtoDetail ToDto(TModel model);
        TModel ToModel(TDtoDetail dto);
        List<TDtoSummary> ToDtos(List<TModel> models);
        List<TModel> ToModels(List<TDtoSummary> dtos);
    }
}