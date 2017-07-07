﻿namespace Cilesta.Security.Katarina.Interfaces
{
    using Cilesta.Domain.Interfaces;
    using Cilesta.Security.Interfaces;
    using Cilesta.Security.Katarina.Entities;

    public interface IUserService : IUserProvider, IDomainService<User>
    {

    }
}
