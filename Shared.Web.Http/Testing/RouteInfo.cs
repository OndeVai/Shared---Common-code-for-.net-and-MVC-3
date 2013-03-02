#region

using System;

#endregion

namespace Shared.Web.Http.Testing
{
    public class RouteInfo
    {
        public Type Controller { get; set; }

        public string Action { get; set; }
    }
}