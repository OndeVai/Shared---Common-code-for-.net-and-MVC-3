#region

using System;

#endregion

namespace Shared.Web.Mvc.Navigation.Model
{
    public class SeoNavLink
    {
        public DateTime LastModified { get; set; }
        public double Priority { get; set; }
        public string Url { get; set; }
    }
}