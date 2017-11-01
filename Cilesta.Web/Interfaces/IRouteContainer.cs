namespace Cilesta.Web.Interfaces
{
    using System.Web.Routing;

    public interface IRouteContainer
    {
        void Init(RouteCollection routeCollection);
    }
}
