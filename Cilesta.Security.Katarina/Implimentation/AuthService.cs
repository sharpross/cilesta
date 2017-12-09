namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using System.Web;
    using Castle.Windsor;
    using Entities;
    using Interfaces;
    using Models;
    using Security.Interfaces;
    using Security.Models;

    public class AuthService : IAuthService
    {
        public IWindsorContainer Container { get; set; }

        public IUserService UserService { get; set; }

        public IUser GetCurrentUser()
        {
            User user = null;

            var cookie = HttpContext.Current.Request.Cookies;

            if (cookie[Constants.CookieName] == null)
            {
                return null;
            }

            UserService = Container.Resolve<IUserService>();

            var cookieKey = cookie[Constants.CookieName];

            if (cookieKey != null)
            {
                var login = cookieKey[Constants.CookieUserName];
                var id = int.Parse(cookieKey[Constants.CookieUserId]);

                ///TODO: make filter
                user = UserService.GetAll()
                    .FirstOrDefault(x => x.Login.ToLower() == login.ToLower() && x.Id == id);
            }

            return user;
        }

        public IUser GetUserFromCookie(HttpCookie cookie)
        {
            IUser user = null;

            var login = cookie[Constants.CookieUserName];
            var id = int.Parse(cookie[Constants.CookieUserId]);

            if (!string.IsNullOrEmpty(login) && id != -1)
            {
                UserService = Container.Resolve<IUserService>();

                user = UserService.GetByLoginId(login, id);
            }

            return user;
        }

        public IAuthResult Login(ILoginModel model)
        {
            var result = new AuthResult
            {
                Message = Constants.MessageLoginFailUnknow,
                Success = false
            };

            UserService = Container.Resolve<IUserService>();
            var user = UserService.GetByLoginPassword(model.Login.ToLower(), model.Password);

            if (user != null)
            {
                result.Success = true;
                result.Message = Constants.MessageLoginSuccess;
                result.Login = user.Login;
                result.UserID = user.Id.ToString();
            }

            return result;
        }
    }
}