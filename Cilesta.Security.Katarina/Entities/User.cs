namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Security.Models;
    using Data.Katarina.Models;

    public class User : Entity, IUserModel
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }
    }
}
