namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using Cilesta.DataAnnotation.Interfaces;

    public class StringValidatorConfig : IValidatorConfig
    {
        public object Value { get; set; }

        public string FieldCode { get; set; }

        public int MinLenght { get; set; }

        public int MaxLenght { get; set; }
    }
}
