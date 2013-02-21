#region

using System.Linq;

#endregion

namespace Shared.Domain.Logic
{
    public class ExceptionThrowerEntityValidator : IEntityValidator
    {
        #region IEntityValidator Members

        public bool Validate(RulesEntityBase rulesEntity)
        {
            if (rulesEntity.GetBrokenRules().Any())
            {
                throw new BusinessRuleException("", rulesEntity.GetBrokenRules());
            }
            return true;
        }

        #endregion
    }
}