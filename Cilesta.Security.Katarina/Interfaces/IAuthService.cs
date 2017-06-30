namespace Cilesta.Security.Katarina.Interfaces
{
    using System.Web;
    using Cilesta.Security.Models;

    public interface IAuthService
    {
        IUserModel GetCurrentUser(HttpRequestBase request);

        IAuthResult Login(ILoginModel model);
    }
}
