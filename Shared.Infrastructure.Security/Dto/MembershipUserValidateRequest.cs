namespace Shared.Infrastructure.Security.Dto
{
    public class MembershipUserValidateRequest : BaseUserRequest
    {
        public MembershipUserValidateRequest(string userName, string password)
            : base(userName, password)
        {
        }
    }
}