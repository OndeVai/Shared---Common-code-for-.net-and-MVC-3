namespace Shared.Infrastructure.Security.Dto
{
    public abstract class BaseUserRequest
    {
        protected BaseUserRequest(string userName, string password)
        {
            UserInfo = new MembershipUserLogonInfo(userName, password);
        }

        public MembershipUserLogonInfo UserInfo { get; private set; }
    }
}