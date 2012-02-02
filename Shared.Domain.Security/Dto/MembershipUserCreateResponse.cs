namespace Shared.Domain.Security.Dto
{
    public class MembershipMembershipUserCreateResponse : MembershipUserResponse
    {
        public MembershipMembershipUserCreateResponse(object providerUserKey, bool isApproved)
            : base(providerUserKey, isApproved)
        {
        }
    }

    public class MembershipUserResponse
    {
        public MembershipUserResponse(object providerUserKey, bool isApproved)
        {
            ProviderUserKey = providerUserKey;
            IsApproved = isApproved;
        }

        public object ProviderUserKey { get; private set; }
        public bool IsApproved { get; private set; }
    }
}