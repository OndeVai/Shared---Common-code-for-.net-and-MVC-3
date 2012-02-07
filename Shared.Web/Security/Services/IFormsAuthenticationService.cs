namespace Shared.Web.Security.Services
{
    public interface IFormsAuthenticationService
    {
        string LogonUrl { get; }
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}