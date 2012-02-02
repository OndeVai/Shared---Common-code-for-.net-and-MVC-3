#region

using System;
using System.Linq.Expressions;
using System.Reflection;

#endregion

namespace ronin.Reflection
{
    public static class TypeHelper
    {
        public static string GetPropertyName(LambdaExpression property)
        {
            if (property.Body.NodeType != ExpressionType.MemberAccess)
            {
                return string.Empty;
            }

            var memberAccess = property.Body as MemberExpression;

            if (memberAccess == null || memberAccess.Member.MemberType != MemberTypes.Property)
            {
                return string.Empty;
            }
            return memberAccess.Member.Name;
        }

        public static Expression<Func<TModel, object>> GetPropertyLambda<TModel>(string propertyName)
        {
            var param = Expression.Parameter(typeof (TModel), "arg");

            Expression member = Expression.Property(param, propertyName);

            if (member.Type.IsValueType)
            {
                member = Expression.Convert(member, typeof (object));
            }
            return Expression.Lambda<Func<TModel, object>>(member, param);
        }
    }
}