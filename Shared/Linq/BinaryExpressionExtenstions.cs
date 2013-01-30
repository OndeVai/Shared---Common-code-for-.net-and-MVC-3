#region

using System;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Shared.Linq
{
    public static class BinaryExpressionExtenstions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return BinaryOnExpressions(left, ExpressionType.AndAlso, right);
        }

        public static Expression<Func<T, bool>> OrElse<T>(
            this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return BinaryOnExpressions(left, ExpressionType.OrElse, right);
        }


        public static Expression<Func<T, bool>> BinaryOnExpressions<T>(
            this Expression<Func<T, bool>> left,
            ExpressionType binaryType,
            Expression<Func<T, bool>> right)
        {
            // Invoke that lambda with my parameter and give me the bool back, KKTHX
            var rightInvoke = Expression.Invoke(right, left.Parameters.Cast<Expression>());

            // make a binary expression between the results (i.e. AndAlso(&&), OrElse(||), etc)
            var binExpression = Expression.MakeBinary(binaryType, left.Body, rightInvoke);

            // Wrap it in a lambda and send it back
            return Expression.Lambda<Func<T, bool>>(binExpression, left.Parameters);
        }
    }
}