#region

using Shared.Domain.Security.Dto;

#endregion

namespace Shared.Domain.Security.Services
{
    public interface IMembershipService
    {
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