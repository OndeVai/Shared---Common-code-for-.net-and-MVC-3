#region

using System.Web.Mvc;
using Shared.Domain.Logic;
using Shared.Web.Mvc.Infrastructure.ActionResults;

#endregion

namespace Shared.Web.Mvc.Infrastructure.ActionFilters
{
    public class BusinessRuleExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        #region IExceptionFilter Members

        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled) //&& filterContext.HttpContext.Request.IsJsonRequest()) --add back when doing ajax
            {
                var busRuleException = filterContext.Exception as BusinessRuleException;
                if (busRuleException != null)
                {
                    filterContext.Result = new CustomJsonResult(busRuleException.Message);
                    filterContext.ExceptionHandled = true;
                }
            }
        }

        #endregion
    }
}