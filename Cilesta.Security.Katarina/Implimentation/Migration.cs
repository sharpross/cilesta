namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using Castle.Windsor;
    using Cilesta.Utils.Common;
    using Data.Interfaces;
    using Domain;
    using Domain.Katarina.Implimentation;
    using Entities;
    using Interfaces;
    using Constants = Security.Constants;

    public class UserMigration : IMigration
    {
        private readonly List<string> _roleNames = new List<string>();

        public IUserService UserService { get; set; }

        public IRoleService RoleService { get; set; }

        public IRolePermissionService RolePermissionMapService { get; set; }

        public IUserRoleService UserRoleMapService { get; set; }

        private IUserManager UserManager { get; set; }

        public string Description => "Миграция пользователей и ролей";
        
        public string[] Depends => new string[1];

        public IWindsorContainer Container { get; set; }

        public string Code => "UserMigration";

        public void Migrate()
        {
            _roleNames.AddRange(new[] {"Администратор", "Модератор", "Пользователь"});

            CreateRoles();
            CreateUsers();
        }

        public bool Need()
        {
            InitService();

            if (!ValidateRoles())
            {
                return true;
            }

            if (!ValidateUsers())
            {
                return true;
            }

            return true;
        }

        private void InitService()
        {
            RoleService = Container.Resolve<IRoleService>();
            UserService = Container.Resolve<IUserService>();
            RolePermissionMapService = Container.Resolve<IRolePermissionService>();
            UserRoleMapService = Container.Resolve<IUserRoleService>();
            UserManager = Container.Resolve<IUserManager>();
        }

        private bool ValidateUsers()
        {
            var filter = new Filter();
            filter.Add("Login", LogicalType.Eq, Constants.AdminLogin);

            var exist = UserService.GetAll(filter).Any();

            if (!exist)
            {
                return false;
            }

            return true;
        }

        private bool ValidateRoles()
        {
            foreach (var role in _roleNames)
            {
                var filter = new Filter();
                filter.Add("Name", LogicalType.Eq, role);

                var exist = RoleService.GetAll(filter).Any();

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

            var admin = new User
            {
                Email = "rt.sharpross@gmail.com",
                Login = Constants.AdminLogin,
                Password = password
            };

            UserManager.AddUser(admin, Constants.RoleNameAdmin);
        }

        private void CreateRoles()
        {
            var existRoles = RoleService.GetAll();

            foreach (var name in _roleNames)
            {
                var exist = existRoles.Any(x => x.Name == name);

                if (!exist)
                {
                    RoleService.Save(new Role {Name = name});
                }
            }
        }
    }
}