namespace Cilesta.Web.Katarina.Controllers
{
    using System.Web.Mvc;
    using Castle.Core.Logging;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Web.Interfaces;

    [OutputCache(Duration = 0, Location = System.Web.UI.OutputCacheLocation.None)]
    public class BaseController : Controller, ICilestaController
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }
        
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var isAuth = !(this.HttpContext.User.Identity is AnonymousUser);

            ViewBag.IsAuth = isAuth;

            if (isAuth)
            {
                ViewBag.User = this.HttpContext.User.Identity.Name;
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
