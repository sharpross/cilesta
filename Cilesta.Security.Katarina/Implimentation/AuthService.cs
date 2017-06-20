namespace Cilesta.Security.Katarina.Implimentation
{
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Models;
    using Cilesta.Security.Models;

    public class AuthService : IAuthService
    {
        public IUserModel GetCurrentUser()
        {
            UserSystem user = null;

            return user;
        }

        public IAuthResult Login(ILoginModel model)
        {
            var result = new AuthResult()
            {
                Message = Constants.MessageLoginFailUnknow,
                Success = false
            };
            
            return result;
        }
    }
}
