namespace FreshExpress.Gain.Web.Util.Security
{
    public interface IFormsAuthenticationService
    {
        string LogonUrl { get; }
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}