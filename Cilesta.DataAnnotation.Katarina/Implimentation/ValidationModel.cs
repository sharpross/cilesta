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

            var fields = this.GetType().GetProperties();
            var va = typeof(IModelValidationAttribute);

            foreach (var field in fields)
            {
                var attributes = new List<IModelValidationAttribute>();

                var customAttributes = field.GetCustomAttributes(false);

                foreach (var attribute in customAttributes)
                {
                    var isValidationAttribute = attribute.GetType().GetInterfaces().Any(x => x == typeof(IModelValidationAttribute));

                    if (isValidationAttribute)
                    {
                        var fieldErrors = this.ProccessField(field, (IModelValidationAttribute)attribute);
                        errors.AddRange(fieldErrors);
                    }
                }
            }

            var result = new ValidationResult(errors);

            return result;
        }

        private List<IFieldValidationInfo> ProccessField(PropertyInfo prop, IModelValidationAttribute attribute)
        {
            var result = new List<IFieldValidationInfo>();

            var value = prop.GetValue(this);

            var errors = attribute.Proccess(value, prop.Name);

            return result;
        }
    }
}
