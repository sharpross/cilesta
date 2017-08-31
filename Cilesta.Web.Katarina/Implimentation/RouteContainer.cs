namespace Cilesta.Web.Katarina.Implimentation
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Interfaces;

    public class RouteContainer : IRouteContainer
    {
        public void Init(RouteCollection routeCollection)
        {
            routeCollection.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
    }
}
