namespace Cilesta.App_Start
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Cilesta.Web.Interfaces;

    public class RouteContainer : IRouteContainer
    {
        public void Init(RouteCollection routeCollection)
        {
            routeCollection.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routeCollection.MapRoute(
                name: "Error",
                url: "{controller}/{action}",
                defaults: new { controller = "Error", action = "Index" }
            );

            routeCollection.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
            );

            routeCollection.MapRoute(
                name: "Login",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}