namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using Cilesta.Domain.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Models;
    using Cilesta.Utils.Common;

    public class UserService : DomainService<User>, IUserService
    {
        public IUser GetByLoginId(string login, int id)
        {
            var filter = new Filter();
            filter.Add("Login", Domain.LogicalType.Eq, login);
            filter.Add("Id", Domain.LogicalType.Eq, id);
            filter.Take(1);

            var result = this.GetAll(filter);

            return result.FirstOrDefault();
        }

        public IUser GetByLoginPassword(string login, string password)
        {
            var mdmPassword = SecurityHelper.EncryptPassword(password);

            var filter = new Filter();
            filter.Add("Login", Domain.LogicalType.Eq, login);
            filter.Add("Password", Domain.LogicalType.Eq, mdmPassword);
            filter.Take(1);

            var result = this.GetAll(filter);

            return result.FirstOrDefault();
        }
    }
}
