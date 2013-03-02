#region

using System;
using System.Linq.Expressions;

#endregion

namespace Shared.Reflection
{
    public static class ExpressionExtensions
    {
        public static string ResolvePropertyName<T, TValue>(
            this Expression<Func<T, TValue>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                if (u != null) expr = u.Operand as MemberExpression;
            }
            if (expr == null) throw new InvalidOperationException("Expression not resolved");
            var exprVal = expr.ToString();
            return exprVal.Substring(exprVal.IndexOf(".", StringComparison.Ordinal) + 1);
        }

        public static string GetMemberName(this Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            var expression1 = expression as MemberExpression;
            if (expression1 != null)
            {
                // Reference type property or field
                var memberExpression = expression1;
                return memberExpression.Member.Name;
            }

            var callExpression = expression as MethodCallExpression;
            if (callExpression != null)
            {
                // Reference type method
                var methodCallExpression =
                    callExpression;
                return methodCallExpression.Method.Name;
            }

            var unaryExpression1 = expression as UnaryExpression;
            if (unaryExpression1 != null)
            {
                // Property, field of method returning value type
                var unaryExpression = unaryExpression1;
                return GetMemberName(unaryExpression);
            }

            throw new ArgumentException("Invalid expression");
        }

        public static string GetMemberName<T, TReturn>(this Expression<Func<T, TReturn>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentException(
                    "The expression cannot be null.");
            }

            return GetMemberName(expression.Body);
        }

        private static string GetMemberName(
            UnaryExpression unaryExpression)
        {
            var operand = unaryExpression.Operand as MethodCallExpression;
            if (operand != null)
            {
                var methodExpression =
                    operand;
                return methodExpression.Method.Name;
            }

            return ((MemberExpression) unaryExpression.Operand)
                .Member.Name;
        }
    }
}