#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Shared.Domain.Logic
{
    public abstract class ComponentModelRulesEntityBase<TID> : RulesEntityBase<TID>
    {
        protected ComponentModelRulesEntityBase(TID id)
            : base(id)
        {
        }

        public virtual bool IsNew
        {
            get { return Id.Equals(default(TID)); }
        }

        protected override void Validate()
        {
            Validate(this);
        }

        protected void Validate(object target)
        {
            var ctx = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(target, ctx, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                AddBrokenRule(new BusinessRule(validationResult.ErrorMessage));
            }
        }
    }
}