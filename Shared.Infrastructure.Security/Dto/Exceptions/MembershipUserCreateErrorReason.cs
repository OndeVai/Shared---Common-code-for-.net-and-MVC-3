﻿namespace Shared.Infrastructure.Security.Dto.Exceptions
{
    public enum MembershipUserCreateErrorReason
    {
        Success,
        InvalidUserName,
        InvalidPassword,
        InvalidQuestion,
        InvalidAnswer,
        InvalidEmail,
        DuplicateUserName,
        DuplicateEmail,
        UserRejected,
        InvalidProviderUserKey,
        DuplicateProviderUserKey,
        ProviderError,
    }
}