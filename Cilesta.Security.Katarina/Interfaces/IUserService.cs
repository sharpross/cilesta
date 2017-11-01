namespace Cilesta.Security.Katarina.Interfaces
{
    using Domain.Interfaces;
    using Entities;
    using Security.Interfaces;

    public interface IUserService : IDomainService<User>, IUserProvider
    {
    }
}