namespace Cilesta.Security.Katarina.Entities
{
    using System.Collections.Generic;
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class UserRole : Entity, IUserRole
    {
        public virtual User User { get; set; }

        public virtual IList<Role> Roles { get; set; }

        public UserRole()
        {
            this.Roles = new List<Role>();
        }
    }
}
