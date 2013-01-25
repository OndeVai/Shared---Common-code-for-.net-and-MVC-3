using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Logic
{
    public abstract class ComponentModelEntityBase<TID> : EntityBase<TID>
    {
        protected ComponentModelEntityBase(TID id)
            : base(id)
        {
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

        protected bool IsNew
        {
            get { return Id.Equals(default(TID)); }
        }
    }
}