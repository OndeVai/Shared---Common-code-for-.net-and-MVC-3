namespace Shared.Infrastructure.Security.Services
{
    public class UserChangePasswordRequest
    {
        public UserChangePasswordRequest(string userName, string newPassword)
        {
            UserName = userName;
            NewPassword = newPassword;
        }

        public string UserName { get; private set; }

        public string NewPassword { get; private set; }
    }
}