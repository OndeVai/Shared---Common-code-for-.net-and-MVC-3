#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

#endregion

namespace Shared.Web.Mvc.Infrastructure.Validation
{
    public class CustomDataTypeAttributeAdapter : DataAnnotationsModelValidator<DataTypeAttribute>
    {
        public CustomDataTypeAttributeAdapter(ModelMetadata metadata, ControllerContext context, DataTypeAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var thisDataType = Attribute.DataType;

            if (thisDataType == DataType.EmailAddress) return new[] {new ModelClientValidationDataTypeRule(Attribute.FormatErrorMessage(Metadata.GetDisplayName()), "email")};

            if (thisDataType == DataType.Date || thisDataType == DataType.DateTime) 
                return new[] {new ModelClientValidationDataTypeRule(Attribute.FormatErrorMessage(Metadata.GetDisplayName()), "date")};

            return base.GetClientValidationRules();
        }
    }
}