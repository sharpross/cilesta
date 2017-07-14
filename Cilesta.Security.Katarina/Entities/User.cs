namespace Cilesta.Security.Katarina.Entities
{
    using System;
    using Cilesta.Security.Models;
    using Data.Katarina.Models;

    public class User : Entity, IUser
    {
        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual string Email { get; set; }

        public virtual bool Blocked { get; set; }
    }
}
