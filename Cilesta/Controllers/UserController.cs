namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Web.Katarina.Controllers;

    public class UserController : DomainController<User>
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}