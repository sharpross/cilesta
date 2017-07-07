namespace Cilesta.Security.Interfaces
{
    using Cilesta.Security.Models;

    public interface IUserProvider
    {
        IUser GetByLoginPassword(string login, string password);

        IUser GetByLoginId(string login, int id);
    }
}
