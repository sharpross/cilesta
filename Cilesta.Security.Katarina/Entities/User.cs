namespace Cilesta.Security.Katarina.Entities
{
    using Cilesta.Data.Models;
    using Cilesta.Security.Models;

    public class User : IUserModel, IEntity
    {
        public ulong Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }
    }
}
