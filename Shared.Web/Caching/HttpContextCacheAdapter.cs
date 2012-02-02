#region

using System;
using System.Web;
using System.Web.Caching;
using Shared.Caching.Providers;

#endregion

namespace Shared.Web.Caching
{
    public class HttpContextCacheAdapter : ICacheAdapter
    {
        private readonly Cache _cache;

        public HttpContextCacheAdapter()
        {
            _cache = HttpContext.Current.Cache;
        }

        #region ICacheAdapter Members

        public T GetCachedItem<T>(string key, int duration, Func<T> retrieveFunction) where T : class
        {
            var cachedItem = (T) _cache[key];
            if (cachedItem == null)
            {
                cachedItem = retrieveFunction();
                _cache.Insert(key, cachedItem, null, DateTime.Now.AddSeconds(duration), TimeSpan.Zero);
            }
            return cachedItem;
        }

        #endregion
    }
}