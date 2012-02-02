#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

#endregion

namespace Shared.Web.Mvc.Infrastructure.Validation
{

    #region Validation

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidatePasswordLengthAttribute : ValidationAttribute, IClientValidatable
    {
        private const string DEFAULT_ERROR_MESSAGE = "'{0}' must be at least {1} characters long.";
        private readonly int _minCharacters = Membership.Provider.MinRequiredPasswordLength;

        public ValidatePasswordLengthAttribute()
            : base(DEFAULT_ERROR_MESSAGE)
        {
        }

        #region IClientValidatable Members

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
                                                                               ControllerContext context)
        {
            return new[]
                       {
                           new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()),
                                                                     _minCharacters, int.MaxValue)
                       };
        }

        #endregion

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                                 name, _minCharacters);
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;
            if (string.IsNullOrEmpty(valueAsString)) return true;
            return (valueAsString.Length >= _minCharacters);
        }
    }

    #endregion
}