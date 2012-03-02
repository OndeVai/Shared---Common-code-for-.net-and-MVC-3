#region

using System;

#endregion

namespace Shared.Caching.Adapters
{
    public interface ICacheAdapter
    {
        T GetCachedItem<T>(string key, int duration, Func<T> retrieveFunction) where T : class;
    }
}