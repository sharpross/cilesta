namespace Cilesta.Security.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
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


        }

        public bool Need()
        {
            var result = false;

            this.InitService();

            result = this.ValidateRoles();

            if (result)
            {
                return true;
            }

            return result;
        }

        private void InitService()
        {
            this.RoleService = this.Container.Resolve<IRoleService>();
            this.UserService = this.Container.Resolve<IUserService>();
            this.RolePermissionMapService = this.Container.Resolve<IRolePermissionMapService>();
            this.UserRoleMapService = this.Container.Resolve<IUserRoleMapService>();
        }

        private bool ValidateRoles()
        {
            var result = false;
            
            foreach (var role in this.RoleNames)
            {
                
            }

            return result;
        }

        private void CreateUsers()
        {
            var password = SecurityHelper.EncryptPassword(Security.Constants.AdminPassword);

            var admin = new User()
            {
                Email = "rt.sharpross@gmail.com",
                Login = Constants.AdminLogin,
                Password = password
            };

            this.UserService.Save(admin);
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
