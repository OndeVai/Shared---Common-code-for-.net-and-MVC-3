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
    }
}