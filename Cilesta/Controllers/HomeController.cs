namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Web.Katarina.Implimentation;

    public class HomeController : CilestaController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}