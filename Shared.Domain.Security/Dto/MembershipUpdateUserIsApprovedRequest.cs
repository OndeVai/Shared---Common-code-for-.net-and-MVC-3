namespace Shared.Domain.Security.Dto
{
    public class MembershipUpdateUserIsApprovedRequest
    {
        public MembershipUpdateUserIsApprovedRequest(string userName, bool isApproved)
        {
            UserName = userName;
            IsApproved = isApproved;
        }

        public string UserName { get; private set; }
        public bool IsApproved { get; private set; }
    }
}