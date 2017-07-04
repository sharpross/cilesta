namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class PermissionMap : Entity, IPermissionMap
    {
        Role Role { get; set; }

        Permission Permission { get; set; }
    }
}
