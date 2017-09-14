namespace Cilesta.DataAnnotation.Katarina.Tests.Models
{
    using Cilesta.DataAnnotation.Katarina.Attributes;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class PasswordTestModel : ValidationModel
    {
        [PasswordValidator]
        public string Password { get; set; }
    }
}
