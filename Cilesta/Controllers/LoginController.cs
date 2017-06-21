namespace Cilesta.Controllers
{
    using System;
    using System.Web.Mvc;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Web.Katarina.Implimentation;

    public class LoginController : CilestaController
    {
        public IAuthService AuthService { get; set; }

        [HttpPost]
        public JsonNetResult Login(LoginModel model)
        {
            this.AuthService = this.Container.Resolve<IAuthService>();

            var result = this.AuthService.Login(model);

            if (result.Success)
            {
                
                return JsonNetResult.Success(result);
            }

            return JsonNetResult.Fail(result);
        }

        [HttpPost]
        public JsonNetResult Logout()
        {
            return JsonNetResult.Success();
        }
    }
}