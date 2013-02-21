#region

using System;

#endregion

namespace Shared.Infrastructure
{
    public interface IUriBuilder
    {
        Uri ToAbsolute(string relativeUri);
        Uri ToAbsolute(Uri relativeUri);
    }
}