namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Utils;
    using Cilesta.Web.Katarina.Controllers;
    using Cilesta.Web.Katarina.Implimentation;

    public class LoginController : CilestaController
    {
        public IAuthService AuthService { get; set; }

        /*[HttpPost]
        [SkipAuthorization]
        public JsonNetResult Login(LoginModel model)
        {
            this.AuthService = this.Container.Resolve<IAuthService>();

            var result = this.AuthService.Login(model);

            if (result.Success)
            {
                CookiHelper.SetCookie(this.HttpContext.Response, result.Login, result.UserID);
                return JsonNetResult.Success(result);
            }

            return JsonNetResult.Fail(result);
        }*/

        [HttpPost]
        [SkipAuthorization]
        public JsonNetResult Login(string login, string password)
        {
            this.AuthService = this.Container.Resolve<IAuthService>();

            var model = new LoginModel()
            {
                Login = login,
                Password = password
            };

            var result = this.AuthService.Login(model);

            if (result.Success)
            {
                CookiHelper.SetCookie(this.HttpContext.Response, result.Login, result.UserID);
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