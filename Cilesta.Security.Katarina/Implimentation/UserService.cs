namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Linq;
    using Cilesta.Domain.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Security.Models;
    using NHibernate.Criterion;

    public class UserService : DomainService<User>, IUserService
    {
        public IUser GetByLoginId(string login, int id)
        {
            var criteria = this.Bridge.Session.CreateCriteria<User>();

            criteria.Add(Expression.Eq("Login", login));
            criteria.Add(Expression.Eq("Id", id));
            criteria.SetMaxResults(1);
            criteria.SetReadOnly(true);
            var result = criteria.List<User>().First();

            return result;
        }

        public IUser GetByLoginPassword(string login, string password)
        {
            var criteria = this.Bridge.Session.CreateCriteria<User>();

            criteria.Add(Expression.Eq("Login", login));
            criteria.Add(Expression.Eq("Password", password));
            criteria.SetMaxResults(1);
            criteria.SetReadOnly(true);
            var result = criteria.List<User>().First();

            return result;
        }
    }
}
