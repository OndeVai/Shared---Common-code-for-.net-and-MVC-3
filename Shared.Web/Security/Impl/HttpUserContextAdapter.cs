#region

using System.Web;
using Shared.Security;

#endregion

namespace Shared.Web.Security.Impl
{
    public abstract class HttpUserContextAdapter : IUserContextAdapter
    {
        protected HttpUserContextAdapter()
        {
            Context = HttpContext.Current;
        }

        protected HttpContext Context { get; private set; }

        #region IUserContextAdapter Members

        public bool IsAuthenticated
        {
            get { return Context.Request.IsAuthenticated; }
        }

        public string CurrentUserName
        {
            get { return Context.User != null ? Context.User.Identity.Name : null; }
        }

        #endregion
    }
}