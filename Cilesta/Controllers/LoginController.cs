namespace Cilesta.Controllers
{
    using System.Web.Mvc;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Attributes;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Models;
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
        public ActionResult Index(string login, string password)
        {
            var loginModel = new LoginModel()
            {
                Login = login,
                Password = password
            };

            var result = this.DoLogin(loginModel);

            if (result.Success)
            {
                return this.Redirect("~/Home/Index");
            }
            else
            {
                return this.View(result);
            }
        }

        [HttpPost]
        [SkipAuthorization]
        public ActionResult Login(LoginModel loginModel)
        {
            var result = this.DoLogin(loginModel);

            if (result.Success)
            {
                return JsonNetResult.Success(result);
            }

            return JsonNetResult.Fail(result);
        }
        
        public ActionResult Logout()
        {
            CookiHelper.RemoveCookie(this.HttpContext.Response);

            return this.Redirect("~/Home/Index");
        }

        private IAuthResult DoLogin(LoginModel loginModel)
        {
            this.AuthService = this.Container.Resolve<IAuthService>();

            var result = this.AuthService.Login(loginModel);

            if (result.Success)
            {
                CookiHelper.SetCookie(this.HttpContext.Response, result.Login, result.UserID);
            }

            return result;
        }
    }
}