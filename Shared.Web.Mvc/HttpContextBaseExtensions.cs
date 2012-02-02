#region

using System.Linq;
using System.Web;
using System.Web.Mvc;

#endregion

namespace Shared.Web.Mvc
{
    public static class HttpContextBaseExtensions
    {
        public static bool IsJsonRequest(this HttpRequestBase httpRequestBase)
        {
            if (httpRequestBase.IsAjaxRequest())
            {
                if (httpRequestBase.AcceptTypes != null)
                    return httpRequestBase.AcceptTypes.Any(t => t.ToLower() == "application/json");
            }
            return false;
        }
    }
}