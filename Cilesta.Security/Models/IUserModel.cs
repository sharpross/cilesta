namespace Cilesta.Security.Models
{
    using Cilesta.Data.Models;

    public interface IUserModel : IEntity
    {
        string Login { get; set; }

        string Password { get; set; }

        string Email { get; set; }
    }
}
