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

                field.GetCustomAttributes(false)
                    .Where(x => {
                        //x.GetType().Inte is IModelValidationAttribute
                        return true;
                    })
                    .Select(x => {
                        attributes.Add(x as IModelValidationAttribute);
                        return false;
                    });

                if (attributes.Count() > 0)
                {
                    var fieldErrors = this.ProccessField(field, (List<IModelValidationAttribute>)attributes);

                    errors.AddRange(fieldErrors);
                }
            }

            var result = new ValidationResult(errors);

            return result;
        }

        private List<IFieldValidationInfo> ProccessField(PropertyInfo prop, List<IModelValidationAttribute> attributes)
        {
            var result = new List<IFieldValidationInfo>();

            var value = prop.GetValue(this);

            foreach (var attribute in attributes)
            {
                var errors = attribute.Proccess(value, prop.Name);
            }

            return result;
        }
    }
}
