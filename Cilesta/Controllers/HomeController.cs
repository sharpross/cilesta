namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Web.Katarina.Controllers;

    [SkipAuthorization]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}