#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ronin.Reflection;

#endregion

namespace ronin.Domain.Validation
{
    public class RulesException : Exception
    {
        private static readonly Expression<Func<object, object>> ThisObject = x => x;
        public readonly IList<RuleViolation> Errors = new List<RuleViolation>();

        public void ErrorForModel(string message)
        {
            Errors.Add(new RuleViolation {Property = ThisObject, Message = message});
        }

        public void ErrorForModel(string message, int code)
        {
            ErrorForModel(string.Format("{0} -- {1}", code, message));
        }
    }

    // Strongly-typed version permits lambda expression syntax to reference properties
    public class RulesException<TModel> : RulesException
    {
        public void ErrorFor<TProperty>(Expression<Func<TModel, TProperty>> property, string message)
        {
            Errors.Add(new RuleViolation {Property = property, Message = message});
        }

        public void ErrorFor(string propertyName, string message)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                ErrorForModel(message);
            else
            {
                try
                {
                    Errors.Add(new RuleViolation {Property = GetPropertyLambda(propertyName), Message = message});
                }
                catch (ArgumentException)
                {
                    ErrorForModel(message);
                }
            }
        }

        private static Expression<Func<TModel, object>> GetPropertyLambda(string propertyName)
        {
            return TypeHelper.GetPropertyLambda<TModel>(propertyName);
        }
    }

    public class RuleViolation
    {
        public LambdaExpression Property { get; set; }
        public string Message { get; set; }

        public string GetPropertyName()
        {
            return TypeHelper.GetPropertyName(Property);
        }
    }
}