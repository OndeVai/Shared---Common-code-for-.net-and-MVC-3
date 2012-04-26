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

        public virtual void OnException(ExceptionContext filterContext)
        {
            var busRuleException = filterContext.Exception as BusinessRuleException;
            if (busRuleException != null)
            {
                SendJsonException(filterContext, busRuleException.Message);
            }
        }

        #endregion

        protected void SendJsonException(ExceptionContext filterContext, string message, string errorUrl = null)
        {
            if (!filterContext.ExceptionHandled && filterContext.HttpContext.Request.IsJsonRequest())
            {

                filterContext.Result = new CustomJsonResult(message, errorUrl);
                filterContext.ExceptionHandled = true;

            }
        }
    }
}