using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ronin.Web.Mvc.Validation
{
    public class NotValueAttribute : ValidationAttribute
    {
        private readonly string _defaultValue;

        public NotValueAttribute(string defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public override bool IsValid(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(_defaultValue))
            {
                return value.ToString().ToLowerTrim() != _defaultValue.ToLowerTrim();
            }
            return true;
        }

    }

}
