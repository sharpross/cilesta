namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Web.Katarina.Controllers;

    [SkipAuthorization]
    public class ErrorController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult Maintenance()
        {
            return View();
        }
    }
}