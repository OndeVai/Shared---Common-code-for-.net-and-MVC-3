#region

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using Shared.Text;
using Shared.Web.Mvc.Navigation.Model;

#endregion

namespace Shared.Web.Mvc
{
    public class Controller : System.Web.Mvc.Controller
    {
        public JsonResult JsonGet(object data)
        {
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public NavLink MakeLink(string title, string url, bool display = true, bool isSelected = false)
        {
            return new NavLink
            {
                Title = title,
                Url = url,
                IsSelected = isSelected,
                Display = display
            };
        }

        public  ActionNavLink MakeLink(string title, ActionResult actionResult, bool display = true, bool isSelected = false)
        {
            return new ActionNavLink
            {
                Title = title,
                TargetAction = actionResult,
                IsSelected = isSelected,
                Display = display
            };
        }


       

        public static SelectListItem CreateSelectListItem<TValue>(string text, TValue value)
        {
            return new SelectListItem
            {
                Text = text,
                Value = value.ToString()
            };
        }
    }

    public class SEOController : Controller
    {
        //todo make custom actionresult

        public  ContentResult GenerateSiteMap(string rootSite, List<SeoNavLink> links)
        {
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

            return new ContentResult { Content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" + sitemap, ContentType = "text/xml" };

        }

        public ContentResult GenerateUrlList(string rootSite, List<SeoNavLink> links)
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