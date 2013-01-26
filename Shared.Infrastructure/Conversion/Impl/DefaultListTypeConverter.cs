using System.Collections.Generic;
using System.Linq;

namespace Shared.Infrastructure.Conversion.Impl
{
    public abstract  class DefaultListTypeConverter<TDto, TModel> : ITypeConverter<TDto, TModel>
    {
        public abstract TDto ToDto(TModel model);

        public abstract TModel ToModel(TDto dto);

        public List<TDto> ToDtos(List<TModel> models)
        {
            return models.Select(ToDto).ToList();
        }

        public List<TModel> ToModels(List<TDto> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
    }
}