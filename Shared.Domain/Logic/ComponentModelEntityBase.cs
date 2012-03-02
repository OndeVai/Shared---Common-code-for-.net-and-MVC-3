using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Logic
{
    public abstract class ComponentModelEntityBase<TID> : EntityBase<TID>
    {
        protected ComponentModelEntityBase(TID id) : base(id)
        {
        }

        protected override void Validate()
        {
            var ctx = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(this, ctx, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                AddBrokenRule(new BusinessRule(validationResult.ErrorMessage));
            }
        }
    }
}