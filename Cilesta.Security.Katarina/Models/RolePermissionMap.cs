namespace Cilesta.Security.Katarina.Models
{
    using Cilesta.Security.Models;

    public class RolePermissionMap : IRolePermissionMap
    {
        public string AccesseKey { get; set; }

        public PermissionType Permission { get; set; }

        public IRole Role { get; set; }
    }
}
