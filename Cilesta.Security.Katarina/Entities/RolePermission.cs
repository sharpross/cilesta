namespace Cilesta.Security.Katarina.Entities
{
    using System.Collections.Generic;
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class RolePermission : Entity, IRolePermission
    {
        public virtual Role Role { get; set; }

        public virtual PermissionKey Permission { get; set; }

        public virtual IEnumerable<AccessType> Accesses { get; set; }
    }
}
