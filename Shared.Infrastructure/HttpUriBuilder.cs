#region

using System;
using System.Web;

#endregion

namespace Shared.Infrastructure
{
    public class HttpUriBuilder : IUriBuilder
    {
        public Uri ToAbsolute(string relativeUri)
        {
            return new Uri(ToAbsoluteUrl(relativeUri));
        }

        public Uri ToAbsolute(Uri relativeUri)
        {
            return ToAbsolute(relativeUri.ToString());
        }

        private static string ToAbsoluteUrl(string relativeUrl)
        {
            if (string.IsNullOrEmpty(relativeUrl))
                return relativeUrl;
            var httpContext = HttpContext.Current;
            if (httpContext == null)
                return relativeUrl;

            var url = httpContext.Request.Url;

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