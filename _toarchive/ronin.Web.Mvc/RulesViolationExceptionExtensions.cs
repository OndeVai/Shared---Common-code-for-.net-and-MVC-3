using System.Web.Mvc;
using ronin.Domain.Validation;

namespace ronin.Web.Mvc
{
    public static class RulesViolationExceptionExtensions
    {
        public static void CopyTo(this RulesException ex, ModelStateDictionary modelState)
        {
            CopyTo(ex, modelState, null);
        }

        public static void CopyTo(this RulesException ex, ModelStateDictionary modelState, string prefix)
        {
            prefix = string.IsNullOrEmpty(prefix) ? "" : prefix + ".";
            foreach (var propertyError in ex.Errors) {
                var key = ExpressionHelper.GetExpressionText(propertyError.Property);
                modelState.AddModelError(prefix + key, propertyError.Message);
            }
        }
    }
}