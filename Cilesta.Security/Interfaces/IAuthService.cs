namespace Cilesta.Security.Interfaces
{
    using System.Web;
    using Cilesta.Security.Models;

    public interface IAuthService
    {
        IUser GetCurrentUser();

        IAuthResult Login(ILoginModel model);

        IUser GetUserFromCookie(HttpCookie cookie);
    }
}
