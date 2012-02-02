using System.Collections.Generic;

namespace ronin.Domain.Validation
{
    public abstract class BaseValidatibleAdapter<TModel> : IValidatible
    {
        protected BaseValidatibleAdapter()
        {
            RulesHelper = new RulesHelper<TModel>();
        }

        protected RulesHelper<TModel> RulesHelper { get; private set; }

        #region Implementation of IValidatible

        public abstract IList<RuleViolation> GetValidationErrors();

        #endregion
    }
}
