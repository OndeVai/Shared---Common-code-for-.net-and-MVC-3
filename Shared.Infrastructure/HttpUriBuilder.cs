#region

using System;
using System.Web;

#endregion

namespace Shared.Infrastructure
{
    public class HttpUriBuilder : IUriBuilder
    {
        private readonly HttpContextBase _httpContext;

        public HttpUriBuilder(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public Uri ToAbsolute(string relativeUri)
        {
            return new Uri(ToAbsoluteUrl(relativeUri));
        }

        public Uri ToAbsolute(Uri relativeUri)
        {
            return ToAbsolute(relativeUri.ToString());
        }

        private string ToAbsoluteUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;
            var url = _httpContext.Request.Url;
            if (url == null)
                return relativeUrl;


            if (relativeUrl.StartsWith("/"))
                relativeUrl = relativeUrl.Insert(0, "~");
            if (!relativeUrl.StartsWith("~/"))
                relativeUrl = relativeUrl.Insert(0, "~/");

            var port = url.Port != 80 ? (":" + url.Port) : String.Empty;

            return string.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port,
                                 VirtualPathUtility.ToAbsolute(relativeUrl));
        }
    }
}