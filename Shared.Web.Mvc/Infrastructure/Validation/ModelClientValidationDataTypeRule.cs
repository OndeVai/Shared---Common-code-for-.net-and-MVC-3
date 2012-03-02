#region

using System.Web.Mvc;

#endregion

namespace Shared.Web.Mvc.Infrastructure.Validation
{
    public class ModelClientValidationDataTypeRule : ModelClientValidationRule
    {
        public ModelClientValidationDataTypeRule(string errorMessage, string dataType)
        {
            ErrorMessage = errorMessage;
            ValidationType = dataType;
        }
    }
}