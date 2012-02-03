#region

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Shared.Domain.Infrastructure
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string modelErrorMessage, IEnumerable<BusinessRule> businessRules)
        {
            var brokenRules = new StringBuilder(modelErrorMessage);
            foreach (var businessRule in businessRules)
            {
                brokenRules.AppendLine(businessRule.Rule);
            }
        }
    }
}