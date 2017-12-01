namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class EmailValidator : IFieldValidator
    {
        public const string Code = "validator-email";

        private const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        private const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        private string error_NullValue = "Значение не может быть пустым.";
        private string error_NoMatch = "Пожалуйста укажите Email.";
        
        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            if (config.Value == null)
            {
                var message = string.Format(Resources.Error_Empty_Field, config.FieldCode);
                
                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
                
                return result;
            }

            string value = config.Value as string;

            var regex = new Regex(pattern, options);
            var hasMatch = regex.IsMatch(value);

            if (!hasMatch)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, error_NoMatch, ErrorLevel.Critical));
            }

            return result;
        }
    }
}
