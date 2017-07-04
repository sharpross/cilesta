namespace Cilesta.Security.Katarina.Interfaces
{
    using Cilesta.Domain.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Models;

    public interface IUserService : IDomainService<User>
    {
        IUser GetByLoginPassword(string login, string password);

        IUser GetByLoginId(string login, int id);
    }
}
