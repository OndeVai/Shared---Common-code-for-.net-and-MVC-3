using System.Collections.Generic;

namespace Shared.Infrastructure.Conversion
{
    public interface ITypeConverter<TDto,TModel>
    {
        TDto ToDto(TModel model);
        TModel ToModel(TDto dto);
        List<TDto> ToDtos(List<TModel> models);
        List<TModel> ToModels(List<TDto> dtos);
    }
}
