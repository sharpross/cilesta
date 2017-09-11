namespace Cilesta.DataAnnotation.Katarina.Implimentation
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Cilesta.DataAnnotation.Interfaces;

    public class ValidationModel : IValidationModel
    {
        public IValidationResult Validate()
        {
            var errors = new List<IFieldValidationInfo>();

            var fields = this.GetType()
                .GetProperties(System.Reflection.BindingFlags.Public);

            foreach (var field in fields)
            {
                var attributes = field.GetCustomAttributes(false)
                    .Where(x => x.GetType().BaseType is IModelValidationAttribute);

                if (attributes.Count() > 0)
                {  
                    
                }
            }

            var result = new ValidationResult(errors);

            return result;
        }

        private List<IFieldValidationInfo> ProccessField(PropertyInfo prop, IModelValidationAttribute[] attributes)
        {
            var result = new List<IFieldValidationInfo>();

            var value = prop.GetValue(this);

            foreach (var attribute in attributes)
            {
                var errors = attribute.Proccess(value);
            }

            return result;
        }
    }
}
