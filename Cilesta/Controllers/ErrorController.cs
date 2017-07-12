namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Web.Katarina.Controllers;

    public class ErrorController : CilestaController
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