namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using System.Web;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Models;

    public class AuthService : IAuthService
    {
        public IUserService UserService { get; set; }
        
        public IUserModel GetCurrentUser(HttpRequestBase request)
        {
            User user = null;

            return user;
        }

        public IAuthResult Login(ILoginModel model)
        {
            var result = new AuthResult()
            {
                Message = Constants.MessageLoginFailUnknow,
                Success = false
            };

            var user = this.UserService.GetAll().FirstOrDefault(x => x.Login == model.Login);

            if(user != null)
            {
                result.Success = true;
                result.Message = Constants.MessageLoginSuccess;
                result.Login = user.Login;
            }

            return result;
        }
    }
}
