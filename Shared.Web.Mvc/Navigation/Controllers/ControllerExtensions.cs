#region

using System.Globalization;
using System.Web.Mvc;
using Shared.Web.Mvc.Navigation.Model;

#endregion

namespace Shared.Web.Mvc.Navigation.Controllers
{
    public static class ControllerExtensions
    {

        public static NavLink MakeLink(this Controller controller, string title, string url, bool display = true, bool isSelected = false)
        {
            return new NavLink
                       {
                           Title = title,
                           Url = url,
                           IsSelected = isSelected,
                           Display = display
                       };
        }

        public static ActionNavLink MakeLink(this Controller controller, string title, ActionResult actionResult, bool display = true, bool isSelected = false)
        {
            return new ActionNavLink
            {
                Title = title,
                TargetAction = actionResult,
                IsSelected = isSelected,
                Display = display
            };
        }


        public static SelectListItem CreateSelectListItem(this Controller controller, string text, int value)
        {
            return new SelectListItem
            {
                Text = text,
                Value = value.ToString(CultureInfo.InvariantCulture)
            };
        }

    }
}