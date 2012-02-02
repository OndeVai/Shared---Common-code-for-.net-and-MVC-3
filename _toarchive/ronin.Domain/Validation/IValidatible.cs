using System.Collections.Generic;

namespace ronin.Domain.Validation
{
    public interface IValidatible
    {
        IList<RuleViolation> GetValidationErrors();
    }
}
