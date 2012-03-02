#region

using System;

#endregion

namespace Shared.Infrastructure.Security.Dto.Exceptions
{
    public class MembershipUserCreateException : ApplicationException
    {
        public MembershipUserCreateException(MembershipUserCreateErrorReason errorReason)
        {
            ErrorReason = errorReason;
        }

        public MembershipUserCreateErrorReason ErrorReason { get; set; }
    }
}