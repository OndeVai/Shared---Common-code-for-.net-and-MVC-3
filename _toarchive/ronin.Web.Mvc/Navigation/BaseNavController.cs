#region



#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

namespace ronin.Web.Mvc.Navigation
{
    public abstract class BaseNavController : BaseController
    {
        #region protected helpers

        protected NavLink MakeLink(string title, string url, bool isSelected, int tempID)
        {
            return new NavLink
                       {
                           Title = title,
                           Url = url,
                           IsSelected = isSelected,
                           TempID = tempID
                       };
        }

        protected ContentResult GenerateSiteMap(string rootSite, List<SeoNavLink> links)
        {
            //Build RSS for sitemap


            var encoding = Response.ContentEncoding.WebName;
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

            return Content("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" + sitemap, "text/xml");
        }

        protected ContentResult GenerateUrlList(string rootSite, List<SeoNavLink> links)
        {
            var sbUrlList = new StringBuilder();
            foreach (var url in links.Select(l => string.Format("{0}{1}", rootSite, l.Url).ToLowerTrim()).OrderBy(l => l))
            {
                sbUrlList.AppendLine(url);
            }

            return Content(sbUrlList.ToString(), "text/plain");
        }

        #endregion
    }
}