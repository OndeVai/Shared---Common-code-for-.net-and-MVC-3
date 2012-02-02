#region

using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Shared.Domain.Infrastructure
{
    // ReSharper disable UnusedMember.Global
    public abstract class ValueObjectBase
    // ReSharper restore UnusedMember.Global
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        // ReSharper disable PublicConstructorInAbstractClass

        protected abstract void Validate();

        // ReSharper disable UnusedMember.Global
        public void ThrowExceptionIfInvalid()
        // ReSharper restore UnusedMember.Global
        {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Any())
            {
                var issues = new StringBuilder();
                foreach (var businessRule in _brokenRules) issues.AppendLine(businessRule.Rule);

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        // ReSharper disable UnusedMember.Global
        protected void AddBrokenRule(BusinessRule businessRule)
        // ReSharper restore UnusedMember.Global
        {
            _brokenRules.Add(businessRule);
        }
    }
}