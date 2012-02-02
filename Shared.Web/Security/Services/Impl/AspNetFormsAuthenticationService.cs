#region

using System;
using System.Web.Security;

#endregion

namespace FreshExpress.Gain.Web.Util.Security.Impl
{
    public class AspNetFormsAuthenticationService : IFormsAuthenticationService
    {
        #region IFormsAuthenticationService Members

        public void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        public string LogonUrl
        {
            get { return FormsAuthentication.LoginUrl; }
        }

        #endregion
    }
}