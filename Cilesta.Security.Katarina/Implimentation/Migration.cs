namespace Cilesta.Security.Katarina.Implimentation
{
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

        public void Migrate()
        {
            
        }

        public bool Need()
        {
            var hasAdmin = !this.UserService.GetAll().Any(x => x.Login == Security.Constants.AdminLogin);

            return hasAdmin;
        }

        private void CreateUsers()
        {
            var password = SecurityHelper.EncryptPassword(Security.Constants.AdminPassword);

            var admin = new User()
            {
                Email = "rt.sharpross@gmail.com",
                Login = Security.Constants.AdminLogin,
                Password = password
            };

            this.UserService.Save(admin);
        }

        private void CreateRoles()
        {
            var roleAdmin = new Role()
            {
                Name = "Администратор"
            };

            var roleUser = new Role()
            {
                Name = "Пользователь"
            };

            var roleModerator = new Role()
            {
                Name = "Модератор"
            };


        }
    }
}
