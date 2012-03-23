#region

using System;

#endregion

namespace Shared.Infrastructure.Caching.Adapters.Impl
{
    public class NullCacheAdapter : ICacheAdapter
    {
        #region Implementation of ICacheAdapter

        public T GetCachedItem<T>(string key, int duration, Func<T> retrieveFunction) where T : class
        {
            return retrieveFunction();
        }

        #endregion
    }
}