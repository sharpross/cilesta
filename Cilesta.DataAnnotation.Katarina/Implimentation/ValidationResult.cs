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
                
                return Results.Where(x => x.Level == ErrorLevel.Critical).Count() == 0;
            }
        }

        public List<IFieldValidationInfo> Results { get; private set; }

        public ValidationResult(List<IFieldValidationInfo> errors)
        {
            Results = errors;
        }
    }
}
