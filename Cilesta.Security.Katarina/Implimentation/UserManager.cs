namespace Cilesta.Security.Katarina.Implimentation
{
    using System;
    using System.Linq;
    using Castle.Windsor;
    using Cilesta.Domain.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;

    public class UserManager : IUserManager
    {
        public IWindsorContainer Container { get; set; }

        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public IUserRoleService UserRoleService { get; set; }

        public void AddUser(User user)
        {
            this.AddUser(user, Constants.RoleNameUser);
        }

        public void AddUser(User user, string roleName)
        {
            this.UserService = this.Container.Resolve<IUserService>();
            this.UserRoleService = this.Container.Resolve<IUserRoleService>();

            if (string.IsNullOrEmpty(roleName))
            {
                roleName = Constants.RoleNameUser;
            }

            var userRole = new UserRole()
            {
                User = user
            };

            var role = this.GetRole(roleName);

            this.UserService.Save(user);

            userRole.Roles.Add(role);

            this.UserRoleService.Save(userRole);
        }

        private Role GetRole(string name)
        {
            Role role = null;

            var filter = new FilterContext();
            filter.Add("Name", Domain.LogicalType.Equals, name);

            role = this.RoleService.GetAll(filter).FirstOrDefault();

            if (role == null)
            {
                throw new Exception("Роль " + name + " не найдена.");
            }

            return role;
        }
    }
}
