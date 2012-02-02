#region

using System;
using System.Web.Security;
using Shared.Domain.Security.Dto;
using Shared.Domain.Security.Dto.Exceptions;

#endregion

namespace Shared.Domain.Security.Services.Impl
{
    public class AspNetMembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;

        public AspNetMembershipService()
        {
            _provider = Membership.Provider;
        }

        #region Implementation of IMembershipService

        public int MinRequiredPasswordLength
        {
            get { return _provider.MinRequiredPasswordLength; }
        }

        public bool ValidateUser(MembershipUserValidateRequest validateUserRequest)
        {
            var userName = validateUserRequest.UserInfo.UserName;
            var password = validateUserRequest.UserInfo.Password;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                throw new UserMissingLogonInfoException();

            return _provider.ValidateUser(userName, password);
        }

        public MembershipMembershipUserCreateResponse CreateUser(MembershipUserCreateRequest createRequest)
        {
            MembershipCreateStatus status;
            var userName = createRequest.UserInfo.UserName;
            var password = createRequest.UserInfo.Password;
            var email = createRequest.Email;
            var isApproved = createRequest.IsApproved;
            var membershipUser = _provider.CreateUser(userName, password, email, null, null, isApproved, null,
                                                      out status);
            if (status != MembershipCreateStatus.Success)
                throw new MembershipUserCreateException((MembershipUserCreateErrorReason) status);
            if (membershipUser == null || membershipUser.ProviderUserKey == null)
                throw new MembershipUserCreateException(MembershipUserCreateErrorReason.ProviderError);

            return new MembershipMembershipUserCreateResponse(membershipUser.ProviderUserKey, membershipUser.IsApproved);
        }

        public MembershipUserResponse GetUser(string userName)
        {
            var member = GetMember(userName);
            return GetResponseFromMember(member);
        }

        public MembershipUserResponse GetUser(object providerUserKey)
        {
            var member = GetMember(providerUserKey);
            return GetResponseFromMember(member);
        }


        public void UpdateUserIsApproved(MembershipUpdateUserIsApprovedRequest membershipUpdateUserIsApprovedRequest)
        {
            var member = GetMember(membershipUpdateUserIsApprovedRequest.UserName);
            if (member != null)
            {
                member.IsApproved = membershipUpdateUserIsApprovedRequest.IsApproved;
                _provider.UpdateUser(member);
            }
        }

        public void DeleteUser(UserDeleteRequest userDeleteRequest)
        {
            var member = GetMember(userDeleteRequest.UserName);
            if (member != null)
            {
                _provider.DeleteUser(userDeleteRequest.UserName, userDeleteRequest.DeleteAllRelatedData);
            }
        }

        public void ChangePassword(UserChangePasswordRequest userChangePasswordRequest)
        {
            if (string.IsNullOrEmpty(userChangePasswordRequest.UserName))
                throw new ArgumentException("Value cannot be null or empty.", "userChangePasswordRequest.UserName");
            if (string.IsNullOrEmpty(userChangePasswordRequest.NewPassword))
                throw new ArgumentException("Value cannot be null or empty.", "userChangePasswordRequest.NewPassword");


            var membershipUser = GetMember(userChangePasswordRequest.UserName);
            if (membershipUser != null)
            {
                var oldPwd = membershipUser.ResetPassword();
                membershipUser.ChangePassword(oldPwd, userChangePasswordRequest.NewPassword);
            }
        }

        public string GeneratePassword(int length, int numberOfNonAlphanumericCharacters)
        {
            return Membership.GeneratePassword(length, numberOfNonAlphanumericCharacters);
        }

        public string ResetPassword(string userName)
        {
            var newPwd = GeneratePassword(MinRequiredPasswordLength, 1);
            ChangePassword(new UserChangePasswordRequest(userName, newPwd));
            return newPwd;
        }

        #endregion

        private static MembershipUserResponse GetResponseFromMember(MembershipUser member)
        {
            return member != null ? new MembershipUserResponse(member.ProviderUserKey, member.IsApproved) : null;
        }

        private MembershipUser GetMember(string userName)
        {
            return _provider.GetUser(userName, false);
        }

        private MembershipUser GetMember(object providerUserKey)
        {
            return _provider.GetUser(providerUserKey, false);
        }
    }
}