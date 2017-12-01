namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using Interfaces;

    public class BaseValidatorConfig : IValidatorConfig
    {
        public string FieldCaption { get; set; }

        public string Message { get; set; }
        
        public object Value { get; set; }

        public string FieldCode { get; set; }
    }
}