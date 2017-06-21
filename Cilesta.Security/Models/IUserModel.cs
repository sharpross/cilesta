namespace Cilesta.Security.Models
{
    public interface IUserModel : Data.Models.IEntity
    {
        string Login { get; set; }

        string Password { get; set; }
    }
}
