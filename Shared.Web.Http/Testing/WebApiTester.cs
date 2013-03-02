#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Moq;
using NUnit.Framework;
using Shared.Reflection;

#endregion

namespace Shared.Web.Http.Testing
{
    public static class WebApiTester
    {
        public static void ShouldMapTo<TController>(this string url, Expression<Func<TController, object>> actionMethod,
                                                    HttpConfiguration config, HttpMethod httpMethod = null)
            where TController : ApiController
        {
            var uriTest = new Uri(url, UriKind.RelativeOrAbsolute);
            var requestUrl = !uriTest.IsAbsoluteUri ? string.Format("http://test/{0}", url) : url;

            var request = new HttpRequestMessage(httpMethod ?? HttpMethod.Get, requestUrl);

            // act
            var route = RouteRequest(config, request);

            // asserts
            Assert.AreEqual(typeof (TController), route.Controller);
            Assert.AreEqual(route.Action, actionMethod.GetMemberName());
        }


        private static RouteInfo RouteRequest(HttpConfiguration config, HttpRequestMessage request)
            //todo validate values are passed to methods like moq!!
        {
            // create context
            var controllerContext = new HttpControllerContext(config, new Mock<IHttpRouteData>().Object, request);

            // get route data
            var routeData = config.Routes.GetRouteData(request);
            RemoveOptionalRoutingParameters(routeData.Values);

            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
            controllerContext.RouteData = routeData;

            // get controller type
            var controllerDescriptor = new DefaultHttpControllerSelector(config).SelectController(request);
            controllerContext.ControllerDescriptor = controllerDescriptor;

            // get action name
            var actionMapping = new ApiControllerActionSelector().SelectAction(controllerContext);

            return new RouteInfo
                {
                    Controller = controllerDescriptor.ControllerType,
                    Action = actionMapping.ActionName
                };
        }

        private static void RemoveOptionalRoutingParameters(IDictionary<string, object> routeValues)
        {
            var optionalParams = routeValues
                .Where(x => x.Value == RouteParameter.Optional)
                .Select(x => x.Key)
                .ToList();

            foreach (var key in optionalParams)
            {
                routeValues.Remove(key);
            }
        }
    }
}