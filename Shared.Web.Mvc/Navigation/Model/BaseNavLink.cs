using System.Collections.Generic;

namespace Shared.Web.Mvc.Navigation.Model
{
    public abstract class BaseNavLink<TChildren>
    {
        protected BaseNavLink()
        {
            ChildNavLinks = new List<TChildren>();
        }

        public virtual string Title { get; set; }
        public bool IsSelected { get; set; }
        public bool Display { get; set; }
        public List<TChildren> ChildNavLinks { private set; get; }
    }
}