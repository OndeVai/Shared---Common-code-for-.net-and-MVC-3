namespace Shared.Domain.Security.Dto
{
    public class MembershipUserValidateRequest : BaseUserRequest
    {
        public MembershipUserValidateRequest(string userName, string password)
            : base(userName, password)
        {
        }
    }
}