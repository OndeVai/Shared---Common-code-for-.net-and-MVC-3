#region

using System;

#endregion

namespace Shared.Caching.Providers
{
    public interface ICacheAdapter
    {
        T GetCachedItem<T>(string key, int duration, Func<T> retrieveFunction) where T : class;
    }
}