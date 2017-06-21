namespace Cilesta.Security.Models
{
    public interface ILoginModel    
    {
        string Login { get; set; }

        string Password { get; set; }

        bool RemembeMe { get; set; }
    }
}
