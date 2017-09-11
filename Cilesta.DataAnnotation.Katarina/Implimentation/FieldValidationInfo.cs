namespace Cilesta.DataAnnotation.Katarina.Implimentation
{
    using Cilesta.DataAnnotation.Interfaces;

    public class FieldValidationInfo : IFieldValidationInfo
    {
        public string FieldCode { get; private set; }

        public ErrorLevel Level { get; private set; }

        public string Message { get; private set; }

        public FieldValidationInfo(string field, string message, ErrorLevel level)
        {
            this.FieldCode = field;
            this.Message = message;
            this.Level = level;
        }
    }
}
