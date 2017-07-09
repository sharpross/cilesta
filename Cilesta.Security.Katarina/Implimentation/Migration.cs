namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Domain.Katarina.Implimentation;
    using Cilesta.Security.Katarina.Entities;
    using Cilesta.Security.Katarina.Interfaces;
    using Cilesta.Utils.Common;

    public class Migration : IMigration
    {
        public IWindsorContainer Container { get; set; }

        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public IRolePermissionMapService RolePermissionMapService { get; set; }

        public IUserRoleMapService UserRoleMapService { get; set; }

        public string Code => "Миграция пользователей и ролей";

        private List<string> RoleNames = new List<string>();

        public void Migrate()
        {
            this.RoleNames.AddRange(new string[]{ "Администратор", "Модератор", "Пользователь" });

            this.CreateRoles();
            this.CreateUsers();
        }

        public bool Need()
        {
            this.InitService();
            
            if (!this.ValidateRoles())
            {
                return true;
            }

            if (!this.ValidateUsers())
            {
                return true;
            }

            return true;
        }

        private void InitService()
        {
            this.RoleService = this.Container.Resolve<IRoleService>();
            this.UserService = this.Container.Resolve<IUserService>();
            this.RolePermissionMapService = this.Container.Resolve<IRolePermissionMapService>();
            this.UserRoleMapService = this.Container.Resolve<IUserRoleMapService>();
        }

        private bool ValidateUsers()
        {
            var filter = new FilterContext();
            filter.Add("Login", Domain.LogicalType.Equals, Constants.AdminLogin);

            var exist = this.UserService.GetAll(filter).Any();

            if (!exist)
            {
                return false;
            }

            return true;
        }

        private bool ValidateRoles()
        {
            foreach (var role in this.RoleNames)
            {
                var filter = new FilterContext();
                filter.Add("Name", Domain.LogicalType.Equals, role);

                var exist = this.RoleService.GetAll(filter).Any();

                if (!exist)
                {
                    return false;
                }
            }

            return true;
        }

        private void CreateUsers()
        {
            var password = SecurityHelper.EncryptPassword(Constants.AdminPassword);

            var admin = new User()
            {
                Email = "rt.sharpross@gmail.com",
                Login = Constants.AdminLogin,
                Password = password
            };

            this.UserService.Save(admin);

            this.BindRole(admin);
        }

        private void BindRole(User user)
        {
            Role role = null;

            var filter = new FilterContext();

            if (user.Login == Constants.RoleNameAdmin)
            {
                filter.Add("Name", Domain.LogicalType.Equals, Constants.RoleNameAdmin);
            }
            else
            {
                filter.Add("Name", Domain.LogicalType.Equals, Constants.RoleNameUser);
            }

            role = this.RoleService.GetAll(filter).First();

            var userRole = new UserRoleMap()
            {
                User = user
            };

            userRole.Roles.Add(role);

            this.UserRoleMapService.Save(userRole);
        }

        private void CreateRoles()
        {
            var existRoles = this.RoleService.GetAll();

            foreach (var name in this.RoleNames)
            {
                var exist = existRoles.Any(x => x.Name == name);

                if (!exist)
                {
                    this.RoleService.Save(new Role() { Name = name });
                }
            }
        }
    }
}
