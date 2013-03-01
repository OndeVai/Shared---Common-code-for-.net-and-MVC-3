#region

using System;
using System.Net.Http;

#endregion

namespace Shared.Web.Http
{
    public interface IErrorConverter
    {
        HttpResponseMessage ToMessageFor(ApplicationException ex, HttpRequestMessage request);
        HttpResponseMessage ToNotFoundError(string message, HttpRequestMessage request);
    }
}