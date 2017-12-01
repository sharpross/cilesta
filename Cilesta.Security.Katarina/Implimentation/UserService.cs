namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using Cilesta.Utils.Common;
    using Domain;
    using Domain.Katarina.Implimentation;
    using Entities;
    using Interfaces;
    using Security.Models;

    public class UserService : DomainService<User>, IUserService
    {
        public IUser GetByLoginId(string login, int id)
        {
            var filter = new Filter();
            filter.Add("Login", LogicalType.Eq, login);
            filter.Add("Id", LogicalType.Eq, id);
            filter.Take(1);

            var result = GetAll(filter);

            return result.FirstOrDefault();
        }

        public IUser GetByLoginPassword(string login, string password)
        {
            var mdmPassword = SecurityHelper.EncryptPassword(password);

            var filter = new Filter();
            filter.Add("Login", LogicalType.Eq, login);
            filter.Add("Password", LogicalType.Eq, mdmPassword);
            filter.Take(1);

            var result = GetAll(filter);

            return result.FirstOrDefault();
        }
    }
}