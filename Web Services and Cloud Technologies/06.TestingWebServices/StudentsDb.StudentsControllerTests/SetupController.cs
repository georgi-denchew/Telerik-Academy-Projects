using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace StudentsDb.StudentsControllerTests
{
    public static class SetupController
    {
        public static void Create(ApiController controller, string requestType, string service)
        {
            var config = new HttpConfiguration();
            HttpMethod requestMethod = HttpMethod.Post;
            switch (requestType)
            {
                case "post": requestMethod = HttpMethod.Post;
                    break;
                case "get": requestMethod = HttpMethod.Get;
                    break;
                case "delete": requestMethod = HttpMethod.Delete;
                    break;
                case "put": requestMethod = HttpMethod.Put;
                    break;
                default:
                    throw new ArgumentException("Invalid request type");
            }
            var request = new HttpRequestMessage(requestMethod, "http://localhost/api/" + service);
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", service);
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}
