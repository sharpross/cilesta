namespace Cilesta.Security.Katarina.Interfaces
{
    using Entities;

    public interface IUserManager
    {
        IUserService UserService { get; set; }

        IRoleService RoleService { get; set; }

        void AddUser(User user);

        void AddUser(User user, string roleName);
    }
}