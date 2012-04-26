namespace Shared.Web.Infrastructure.Security.Services
{
    public interface IFormsAuthenticationService
    {
        string LogonUrl { get; }
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }
}