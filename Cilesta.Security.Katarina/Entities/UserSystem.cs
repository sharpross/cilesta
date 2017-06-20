namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Security.Models;

    public class UserSystem : IUserModel
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }
    }
}
