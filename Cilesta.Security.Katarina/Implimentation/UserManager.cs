namespace Cilesta.Security.Katarina.Implimentation
{
    using System;
    using System.Linq;
    using Castle.Windsor;
    using Domain;
    using Domain.Katarina.Implimentation;
    using Entities;
    using Interfaces;
    using Constants = Security.Constants;

    public class UserManager : IUserManager
    {
        public IWindsorContainer Container { get; set; }

        public IUserRoleService UserRoleService { get; set; }

        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public void AddUser(User user)
        {
            AddUser(user, Constants.RoleNameUser);
        }

        public void AddUser(User user, string roleName)
        {
            UserService = Container.Resolve<IUserService>();
            UserRoleService = Container.Resolve<IUserRoleService>();

            if (string.IsNullOrEmpty(roleName))
            {
                roleName = Constants.RoleNameUser;
            }

            var userRole = new UserRole
            {
                User = user
            };

            var role = GetRole(roleName);

            UserService.Save(user);

            userRole.Roles.Add(role);

            UserRoleService.Save(userRole);
        }

        private Role GetRole(string name)
        {
            Role role = null;

            var filter = new Filter();
            filter.Add("Name", LogicalType.Eq, name);

            role = RoleService.GetAll(filter).FirstOrDefault();

            if (role == null)
            {
                throw new Exception("Роль " + name + " не найдена.");
            }

            return role;
        }
    }
}