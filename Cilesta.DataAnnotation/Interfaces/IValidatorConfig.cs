namespace Cilesta.DataAnnotation.Interfaces
{
    public interface IValidatorConfig
    {
        object Value { get; set; }

        string FieldCode { get; set; }
        
        string FieldCaption { get; set; }

        string Message { get; set; }
    }
}
