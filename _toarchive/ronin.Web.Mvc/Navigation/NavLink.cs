#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace ronin.Web.Mvc.Navigation
{
    public interface INavLinkBasic
    {
        string Url { get; set; }
    }

    public interface INavLink : INavLinkBasic
    {
        string Title { get; set; }
        bool IsSelected { get; set; }
        int TempID { get; set; }
        List<INavLink> ChildNavLinks { get; }
       
    }

    public class NavLink : INavLink
    {
        public NavLink()
        {
            ChildNavLinks = new List<INavLink>();
        }

        #region INavLink Members

        
        public virtual string Title { get; set; }

        public string Url { get; set; }
        public bool IsSelected { get; set; }
        public int TempID { get; set; }

        public List<INavLink> ChildNavLinks { private set; get; }

       
       

        #endregion
    }

    public class SeoNavLink : INavLinkBasic
    {

        public DateTime LastModified { get; set; }
        public double Priority { get;set; }

        #region Implementation of INavLinkBasic

        public string Url { get; set; }
       

        #endregion
    }
}