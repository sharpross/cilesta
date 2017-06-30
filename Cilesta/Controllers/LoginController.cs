namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Utils;
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
                CookiHelper.SetCookie(this.HttpContext.Response, result.Login);
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