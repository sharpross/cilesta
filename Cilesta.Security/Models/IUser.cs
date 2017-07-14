namespace Cilesta.Security.Models
{
    using Cilesta.Data.Models;

    public interface IUser : IEntity
    {
        string Login { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        bool Blocked { get; set; }
    }
}
