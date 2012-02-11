#region

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace Shared.Domain.Infrastructure
{
    public class BusinessRuleException : ApplicationException
    {
        private readonly StringBuilder _brokenRulesText;

        public BusinessRuleException(string rule)
            : this("", new[] { new BusinessRule(rule) })
        {
        }

        public BusinessRuleException(string modelErrorMessage, IEnumerable<BusinessRule> businessRules)
        {
            var brokenRules = new StringBuilder(modelErrorMessage);
            foreach (var businessRule in businessRules)
            {
                _brokenRulesText = brokenRules.AppendLine(businessRule.Rule);
            }
        }

        public override string Message
        {
            get { return _brokenRulesText.ToString(); }
        }
    }
}