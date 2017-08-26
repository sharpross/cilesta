﻿namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Models.User;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Web.Katarina.Controllers;

    public class UserController : DomainController<User>
    {
        public ViewResult Index()
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
            if (model.IsValid())
            { 
                
            }

            return View(model);
        }
    }
}