namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Web.Katarina.Controllers;

    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}