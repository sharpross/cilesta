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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}