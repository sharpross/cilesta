namespace Cilesta.Web.Katarina.Controllers
{
    using System.Web.Mvc;
    using System.Web.UI;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Interfaces;

    [OutputCache(Duration = 0, Location = OutputCacheLocation.None)]
    public class BaseController : Controller, ICilestaController
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var viewDataBuilders = Container.ResolveAll<IViewDataBuilder>();

            foreach (var builder in viewDataBuilders)
            {
                builder.Build(this);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}