namespace Shared.Domain.Security.Dto
{
    public class MembershipUserLogonInfo
    {
        public MembershipUserLogonInfo(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}