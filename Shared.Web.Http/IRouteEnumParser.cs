#region



#endregion

using System.Web.Http.Routing;

namespace Shared.Web.Http
{
    public interface IRouteEnumParser
    {
        bool TryParseOptional<TEnum>(IHttpRouteData routeData, string paramName, out TEnum? enumVal)
            where TEnum : struct;

        bool TryParseOptional<TEnum>(IHttpRouteData routeData, string paramName) where TEnum : struct;
        bool TryParseRequired<TEnum>(IHttpRouteData routeData, string paramName) where TEnum : struct;
    }
}