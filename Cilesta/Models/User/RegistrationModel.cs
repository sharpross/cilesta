namespace Cilesta.Models.User
{
    using Cilesta.DataAnnotation.Katarina.Attributes;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class RegistrationModel : ValidationModel
    {
        public string Login { get; set; }

        public string Email { get; set; }

        [PasswordValidator]
        public string Password { get; set; }
    }
}