namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using System.Web;
    using Castle.Windsor;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Models;

    public class AuthService : IAuthService
    {
        public IWindsorContainer  Container { get; set; }

        public IUserService UserService { get; set; }
        
        public IUserModel GetCurrentUser()
        {
            User user = null;

            var cookie = HttpContext.Current.Request.Cookies;

            if (cookie != null && cookie[Constants.CookieName] != null)
            {
                return null;   
            }

            this.UserService = this.Container.Resolve<IUserService>();

            var cookieKey = cookie[Constants.CookieName];
            var login = cookieKey[Constants.CookieUserName];
            var id = int.Parse(cookieKey[Constants.CookieUserId]);

            user = this.UserService.GetAll()
                .FirstOrDefault(x => x.Login == login && x.Id == id);

            return user;
        }

        public IUserModel GetUserFromCookie(HttpCookie cookie)
        {
            IUserModel user = null;

            var login = cookie[Constants.CookieUserName];
            var id = int.Parse(cookie[Constants.CookieUserId]);

            if (!string.IsNullOrEmpty(login) && id != -1)
            {
                this.UserService = this.Container.Resolve<IUserService>();

                user = this.UserService.GetByLoginId(login, id);
            }
            
            return user;
        }

        public IAuthResult Login(ILoginModel model)
        {
            var result = new AuthResult()
            {
                Message = Constants.MessageLoginFailUnknow,
                Success = false
            };

            this.UserService = this.Container.Resolve<IUserService>();
            var user = this.UserService.GetByLoginPassword(model.Login.ToLower(), model.Password);

            if(user != null)
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
