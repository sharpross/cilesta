namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Models.User;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Web.Katarina.Controllers;

    public class UserController : ListController<User>
    {
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        [SkipAuthorization]
        public ActionResult Registration()
        {
            var model = new RegistrationModel();

            return View(model);
        }

        [HttpPost]
        [SkipAuthorization]
        public ActionResult Registration(RegistrationModel model)
        {
            var validationResult = model.Validate();

            if (validationResult.IsValid)
            {
                
            }

            return View(model);
        }
    }
}