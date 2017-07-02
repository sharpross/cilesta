namespace Cilesta.Security.Katarina.Interfaces
{
    using Cilesta.Domain.Interfaces;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Models;

    public interface IUserService : IDomainService<User>
    {
        IUserModel GetByLoginPassword(string login, string password);

        IUserModel GetByLoginId(string login, int id);
    }
}
