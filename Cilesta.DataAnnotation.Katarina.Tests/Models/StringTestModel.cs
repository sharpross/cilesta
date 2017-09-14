namespace Cilesta.DataAnnotation.Katarina.Tests.Models
{
    using Cilesta.DataAnnotation.Katarina.Attributes;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class StringTestModel : ValidationModel
    {
        [StringValidator(MinLenght = 5, MaxLenght = 15)]
        public string Name { get; set; }
    }
}
