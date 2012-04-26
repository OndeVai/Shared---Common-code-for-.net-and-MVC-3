#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

#endregion

namespace Shared.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionLinkTitle(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                    string controllerName)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, new {}, new {title = linkText});
        }

        public static MvcHtmlString ActionLinkTitle(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                    string controllerName, string className)
        {
            return htmlHelper.ActionLink(linkText, actionName, controllerName, new {},
                                         new {title = linkText, @class = className});
        }

        public static bool IsCurrentAction(this HtmlHelper helper, string actionName, string controllerName)
        {
            var currentControllerName = (string) helper.ViewContext.RouteData.Values["controller"];
            var currentActionName = (string) helper.ViewContext.RouteData.Values["action"];

            return currentControllerName.Equals(controllerName, StringComparison.CurrentCultureIgnoreCase) &&
                   currentActionName.Equals(actionName, StringComparison.CurrentCultureIgnoreCase);
        }

        
        public static MvcHtmlString TextBoxForEnhanced<T, TValue>(this HtmlHelper<T> htmlHelper,
                                                                  Expression<Func<T, TValue>> expression,
                                                                  IDictionary<string, object> htmlAttributes,
                                                                  int tabIndex = 0, bool isReadOnly = false)
        {
            var member = expression.Body as MemberExpression;
            var maxLength = 150;
            if (member != null)
            {
                var stringLength = member.Member
                                       .GetCustomAttributes(typeof (StringLengthAttribute), false)
                                       .FirstOrDefault() as StringLengthAttribute;
                if (stringLength != null)
                    maxLength = stringLength.MaximumLength;
            }

            htmlAttributes.Add("maxlength", maxLength);
            htmlAttributes.Add("tabindex", tabIndex);
            if (isReadOnly)
                htmlAttributes.Add("readonly", "readonly");

            return htmlHelper.TextBoxFor(expression, htmlAttributes);
        }

        public static MvcForm BeginForm(this HtmlHelper htmlHelper, string actionName, string controllerName,
                                        string className)
        {
            return htmlHelper.BeginForm(actionName, controllerName, FormMethod.Post, new {@class = className});
        }

        public static MvcHtmlString DisplayNameFor<T, TValue>(this HtmlHelper<T> htmlHelper,
                                                              Expression<Func<T, TValue>> expression)
        {
            return MvcHtmlString.Create(ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).DisplayName);
        }


        private static DateTime CoerceDate(object input)
        {
            return input != null ? (DateTime) input : DateTime.MinValue;
        }

        private static bool IsBindingNullDate(DateTime dateTime)
        {
            return dateTime == DateTime.MinValue || dateTime == DateTime.Parse("1/1/1900");
        }

        private static string GetFieldHtmlID<T, TValue>(Expression<Func<T, TValue>> expression, HtmlHelper helper)
        {
            var propertyName = ExpressionHelper.GetExpressionText(expression);
            return helper.ViewData.TemplateInfo.GetFullHtmlFieldId(propertyName);
        }
    }
}