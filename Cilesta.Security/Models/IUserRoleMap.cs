namespace Cilesta.Security.Models
{
    using System.Collections.Generic;

    public interface IUserRoleMap
    {
        IList<IRole> Roles { get; set; }

        IUser User { get; set; }
    }
}
