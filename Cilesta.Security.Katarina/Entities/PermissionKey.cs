namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Security.Models;

    public class PermissionKey : Entity, IPermissionKey
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
