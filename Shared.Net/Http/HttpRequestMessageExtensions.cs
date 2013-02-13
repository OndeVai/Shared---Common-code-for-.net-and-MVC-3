#region

using System.Net.Http;

#endregion

namespace Shared.Net.Http
{
    public static class HttpRequestMessageExtensions
    {
        public static string GetQueryStringValue(this HttpRequestMessage request, string name)
        {
            var requestUri = request.RequestUri.Query;
            var queries = requestUri.Split('&');

            foreach (var s in queries)
            {
                if (s.Contains(name))
                {
                    var index = s.IndexOf('=');
                    var stopIndex = s.IndexOf('&', index);
                    return stopIndex != -1
                               ? s.Substring(index + 1, stopIndex - index - 1)
                               : s.Substring(index + 1, s.Length - index - 1);
                }
            }

            return string.Empty;
        }
    }
}