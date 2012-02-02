using System.Web.Mvc;

namespace Shared.Web.Mvc.Navigation.Model
{
    public class ActionNavLink : BaseNavLink<ActionNavLink>
    {
        public ActionResult TargetAction { get; set; }
    }
}