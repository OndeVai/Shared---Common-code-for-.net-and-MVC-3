#region

using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using ronin.Domain.Validation;

#endregion

namespace ronin.Web.Mvc
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        ///   Get/sets item in cache
        /// </summary>
        /// <typeparam name = "T">the type you are getting/setting</typeparam>
        /// <param name = "key">cache key for item</param>
        /// <param name = "duration">duration to cache in seconds</param>
        /// <param name = "retrieveFunction">the function to execute if cache is empty</param>
        /// <returns></returns>
        protected T GetCachedItem<T>(string key, int duration, Func<T> retrieveFunction) where T : class
        {
            var cachedItem = (T)HttpContext.Cache[key];
            if (cachedItem == null)
            {
                cachedItem = retrieveFunction();
                HttpContext.Cache.Insert(key, cachedItem, null, DateTime.Now.AddSeconds(duration), TimeSpan.Zero);
            }
            return cachedItem;
        }

        
    }
}