#region

using System.Collections.Generic;
using ronin.Domain.Validation;
using ronin.Reflection;
using ronin.ServiceModel.Errors;

#endregion

namespace ronin.ServiceModel
{
    public abstract class BaseService<TDto, TDomain>
    {
        protected TDto MapType(TDomain domain)
        {
            return TypeMappingHelper<TDomain, TDto>.MapType(domain);
        }

        protected IEnumerable<TDto> MapType(IEnumerable<TDomain> domains)
        {
            return TypeMappingHelper<TDomain, TDto>.MapType(domains);
        }

        protected void CheckValidation(RulesException rulesException, IErrorHandler errorHandler)
        {
            if (rulesException.Errors.Count > 0)
                errorHandler.HandleRequestViolationException(rulesException);
        }

        protected void CopyDomainErrors<TDtoParam>(IValidatible domain,
                                                   RulesException<TDtoParam> rulesExceptionDto)
        {
            foreach (var validationError in domain.GetValidationErrors())
            {
                rulesExceptionDto.ErrorFor(validationError.GetPropertyName(), validationError.Message);
            }
        }
    }
}