#region

using System;

#endregion

namespace Shared.Domain.Security.Dto.Exceptions
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