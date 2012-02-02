#region

using System;
using ronin.Domain.Validation;

#endregion

namespace ronin.ServiceModel.Errors
{
    public interface IErrorHandler
    {
        void HandleRequestViolationException(RulesException ruleException);
        void HandleSystemException(Exception exception);
    }
}