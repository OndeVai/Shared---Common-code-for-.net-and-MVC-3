using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using Shared.Text;
using Shared.Web.Mvc.Navigation.Model;

namespace Shared.Web.Mvc.Navigation.Controllers
{
    public static class SEOControllerExtensions
    {
        public static ContentResult GenerateSiteMap(this Controller controller, string rootSite, List<SeoNavLink> links)
        {
            var encoding = controller.Response.ContentEncoding.WebName;
            XNamespace ns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            var urlSet = new XElement(ns + "urlset");
            var sitemap = new XDocument(new XDeclaration("1.0", encoding, null), urlSet);

            urlSet.Add(
                from item in links
                select
                    new XElement(ns + "url",
                                 new XElement(ns + "loc", string.Format("{0}{1}", rootSite, item.Url).ToLowerTrim()),
                                 new XElement(ns + "lastmod", String.Format("{0:yyyy-MM-dd}", item.LastModified)),
                                 new XElement(ns + "changefreq", "always"),
                                 new XElement(ns + "priority", item.Priority)
                    )
                );

            return new ContentResult { Content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" + sitemap, ContentType = "text/xml" };

        }

        public static ContentResult GenerateUrlList(this Controller controller, string rootSite, List<SeoNavLink> links)
        {
            var sbUrlList = new StringBuilder();
            foreach (
                var url in links.Select(l => string.Format("{0}{1}", rootSite, l.Url).ToLowerTrim()).OrderBy(l => l))
            {
                sbUrlList.AppendLine(url);
            }

            return new ContentResult { Content = sbUrlList.ToString(), ContentType = "text/plain" };
        }
    }
}