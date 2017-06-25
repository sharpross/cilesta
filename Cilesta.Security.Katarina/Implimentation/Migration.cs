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

        public string Code => "Миграция пользователей";

        public void Migrate()
        {
            var password = SecurityHelper.EncryptPassword("159753");

            var admin = new User()
            {
                Email = "rt.sharpross@gmail.com",
                Login = "rt.sharpross",
                Password = password
            };
        }

        public bool Need()
        {
            var hasAdmin = !this.UserService.GetAll().Any(x => x.Login == "admin");

            return hasAdmin;
        }
    }
}
