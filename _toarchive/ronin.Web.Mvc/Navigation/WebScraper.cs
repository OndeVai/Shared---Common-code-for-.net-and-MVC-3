#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

#endregion

namespace ronin.Web.Mvc.Navigation
{
    public static class WebScraper
    {
        public static List<NavLink> FindLinks(string url, string baseUrl)
        {
            var w = new WebClient();


            var list = new List<NavLink>();

            if (!string.IsNullOrWhiteSpace(url))
            {
                var file = w.DownloadString(url);
                // 1.
                // FindLinks all matches in file.
                var m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                                       RegexOptions.Singleline);

                // 2.
                // Loop over each match.
                foreach (Match m in m1)
                {
                    var value = m.Groups[1].Value;
                    var i = new NavLink();

                    // 3.
                    // Get href attribute.
                    var m2 = Regex.Match(value, @"href=\""(.*?)\""",
                                         RegexOptions.Singleline);
                    if(!m2.Success)
                        m2 = Regex.Match(value, @"href=\'(.*?)\'",
                                         RegexOptions.Singleline);

                    if (m2.Success)
                    {
                        var uri = m2.Groups[1].Value;
                        i.Url = !uri.Contains("http://") ? baseUrl + uri : uri;
                    }

                    // 4.
                    // Remove inner tags from text.
                    var t = Regex.Replace(value, @"\s*<.*?>\s*", "",
                                          RegexOptions.Singleline);
                    i.Title = t;

                    list.Add(i);
                }
            }
            return list;
        }

        public static List<string> FindContent(string url)
        {
            var w = new WebClient();


            var list = new List<string>();

            if (!string.IsNullOrWhiteSpace(url))
            {
                var file = w.DownloadString(url);
                // 1.
                // FindLinks all matches in file.
                var m1 = Regex.Matches(file, @"(<p.*?>.*?</p>)",
                                       RegexOptions.Singleline);

                // 2.
                // Loop over each match.
                list.AddRange((from Match m in m1 select m.ToString()).Take(3));
            }
            return list;
        }
    }
}