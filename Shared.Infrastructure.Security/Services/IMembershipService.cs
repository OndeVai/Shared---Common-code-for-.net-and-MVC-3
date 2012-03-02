#region

using Shared.Infrastructure.Security.Dto;

#endregion

namespace Shared.Infrastructure.Security.Services
{
    public interface IMembershipService
    {
        //test git
        int MinRequiredPasswordLength { get; }

        bool ValidateUser(MembershipUserValidateRequest validateUserRequest);

        MembershipMembershipUserCreateResponse CreateUser(MembershipUserCreateRequest createRequest);

        MembershipUserResponse GetUser(string userName);

        MembershipUserResponse GetUser(object providerUserKey);

        void UpdateUserIsApproved(MembershipUpdateUserIsApprovedRequest membershipUpdateUserIsApprovedRequest);

        void DeleteUser(UserDeleteRequest userDeleteRequest);

        void ChangePassword(UserChangePasswordRequest userChangePasswordRequest);

        string GeneratePassword(int length, int numberOfNonAlphanumericCharacters);
        

    }
}