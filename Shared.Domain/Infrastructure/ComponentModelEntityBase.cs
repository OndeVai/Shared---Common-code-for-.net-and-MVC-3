using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Domain.Infrastructure
{
    public abstract class ComponentModelEntityBase : EntityBase
    {
       

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