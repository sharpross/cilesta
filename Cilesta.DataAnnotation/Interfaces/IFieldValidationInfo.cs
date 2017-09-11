namespace Cilesta.DataAnnotation.Interfaces
{
    
    public interface IFieldValidationInfo
    {
        string FieldCode { get; }

        ErrorLevel Level { get; }

        string Message { get; }
    }
}
