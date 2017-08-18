namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Utils;
    using Cilesta.Web.Katarina.Controllers;
    using Cilesta.Web.Katarina.Implimentation;

    public class LoginController : BaseController
    {
        public IAuthService AuthService { get; set; }

        [SkipAuthorization]
        public ViewResult Index()
        {
            return View();
        }

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