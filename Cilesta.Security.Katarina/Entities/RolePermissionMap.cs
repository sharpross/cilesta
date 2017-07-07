namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class RolePermissionMap : Entity, IRolePermissionMap
    {
        public virtual string AccesseKey { get; set; }

        public virtual PermissionType Permission { get; set; }

        private Role _role { get; set; }

        public IRole Role 
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value as Role;
            }
        }
    }
}
