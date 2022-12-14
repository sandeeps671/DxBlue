using System.Net.Http.Headers;
using System.Web.Http;

namespace DxBlue
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{action}/{id}",
               //routeTemplate: "{controller}/{action}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );


            //To produce JSON format add this line of code  
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
