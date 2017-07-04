namespace Cilesta.Security.Models
{
    using Cilesta.Data.Models;

    public interface IPermissionMap : IEntity
    {
        string AccessKey { get; set; }
    }
}
