namespace Cilesta.Security.Models
{
    public interface IRolePermissionMap
    {
        string AccesseKey { get; set; }

        PermissionType Permission { get; set; }

        IRole Role { get; set; }
    }
}
