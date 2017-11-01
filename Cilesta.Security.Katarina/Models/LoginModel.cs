namespace Cilesta.Security.Katarina.Models
{
    using Security.Models;

    public class LoginModel : ILoginModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool RemembeMe { get; set; }
    }
}