namespace Cilesta.Security.Katarina.Interfaces
{
    using Cilesta.Security.Models;

    public interface IAuthService
    {
        IUserModel GetCurrentUser();

        IAuthResult Login(ILoginModel model);
    }
}
