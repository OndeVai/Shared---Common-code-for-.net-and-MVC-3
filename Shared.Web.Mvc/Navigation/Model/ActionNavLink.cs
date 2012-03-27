using System.Web.Mvc;

namespace Shared.Web.Mvc.Navigation.Model
{
    public class ActionNavLink : NavLink
    {
        public ActionResult TargetAction { get; set; }
    }
}