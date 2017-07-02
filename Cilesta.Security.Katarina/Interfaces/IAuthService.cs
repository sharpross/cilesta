namespace Cilesta.Security.Katarina.Interfaces
{
    using System.Web;
    using Cilesta.Security.Models;

    public interface IAuthService
    {
        IUserModel GetCurrentUser();

        IAuthResult Login(ILoginModel model);

        IUserModel GetUserFromCookie(HttpCookie cookie);
    }
}
