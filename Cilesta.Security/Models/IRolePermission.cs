namespace Cilesta.Security.Models
{
    using System.Collections.Generic;

    public interface IRolePermission
    {
        IEnumerable<AccessType> Accesses { get; set; }
    }
}
