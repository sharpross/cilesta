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

    public class UserMigration : IMigration
    {
        public IWindsorContainer Container { get; set; }

        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public IRolePermissionService RolePermissionMapService { get; set; }

        public IUserRoleService UserRoleMapService { get; set; }

        private IUserManager UserManager { get; set; }

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
            this.RolePermissionMapService = this.Container.Resolve<IRolePermissionService>();
            this.UserRoleMapService = this.Container.Resolve<IUserRoleService>();
            this.UserManager = this.Container.Resolve<IUserManager>();
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

            this.UserManager.AddUser(admin, Constants.RoleNameAdmin);
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
