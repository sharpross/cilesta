namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using Cilesta.DataAnnotation.Interfaces;

    public class BaseValidatorConfig : IValidatorConfig
    {
        public object Value { get; set; }

        public string FieldCode { get; set; }
    }
}
