namespace Cilesta.Security.Katarina.Entities
{
    using System.Collections.Generic;
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class UserRoleMap : Entity, IUserRoleMap
    {
        public IList<IRole> Roles { get; set; }

        private User _user { get; set; }

        public IUser User
        {
            get 
            {
                return _user;
            }
            set
            {
                _user = value as User;
            }
        }
    }
}
