namespace Cilesta.DataAnnotation.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using Cilesta.DataAnnotation.Interfaces;

    public class ValidationResult : IValidationResult
    {
        public bool IsValid
        {
            get
            {
                return this.Results.Any(x => x.Level == ErrorLevel.Critical);
            }
        }

        public List<IFieldValidationInfo> Results { get; private set; }

        public ValidationResult(List<IFieldValidationInfo> errors)
        {
            this.Results = errors;
        }
    }
}
