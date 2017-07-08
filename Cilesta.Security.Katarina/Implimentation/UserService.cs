namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using Cilesta.Domain.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Models;

    public class UserService : DomainService<User>, IUserService
    {
        public IUser GetByLoginId(string login, int id)
        {
            var filter = new FilterContext();
            filter.Add("Login", Domain.LogicalType.Equals, login);
            filter.Add("Id", Domain.LogicalType.Equals, id);
            filter.SetMax(1);

            var result = this.GetAll(filter);

            return result.FirstOrDefault();
        }

        public IUser GetByLoginPassword(string login, string password)
        {
            var filter = new FilterContext();
            filter.Add("Login", Domain.LogicalType.Equals, login);
            filter.Add("Password", Domain.LogicalType.Equals, password);
            filter.SetMax(1);

            var result = this.GetAll(filter);

            return result.FirstOrDefault();
        }
    }
}
