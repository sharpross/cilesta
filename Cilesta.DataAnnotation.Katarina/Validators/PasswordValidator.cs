namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class PasswordValidator : IFieldValidator
    {
        public const string Code = "validator-password";

        private const int const_MinLenght = 5;

        private const string Regex_Symbols_Lowcase = "[а-я ё a-z]*";
        private const string Regex_Symbols_Uppercase = "[А-Я Ё A-Z]*";
        private const string Regex_Numbers = "[0-9]*";

        private const string error_EmptyPassword = "Пароль не может быть пустым.";
        private const string error_MinLenght = "Минимальная длина поля 5 символов.";

        private const string error_LowUpperCase = "Пароль должен содержать символы верхнего и нижнего регистра.";
        private const string error_NumberCase = "Пароль должен содержать числа от 0 до 9.";

        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            var value = config.Value.ToString();

            result.AddRange(this.ValidateEmpty(value, config.FieldCode)); 
            result.AddRange(this.ValidateMinLenght(value, config.FieldCode)); 
            result.AddRange(this.ValidateRegex(value, config.FieldCode));

            return result;
        }
        
        private List<IFieldValidationInfo> ValidateEmpty(string value, string fieldCode)
        {
            var result = new List<IFieldValidationInfo>();

            if (string.IsNullOrEmpty(value))
            {
                result.Add(new FieldValidationInfo(fieldCode, error_EmptyPassword, ErrorLevel.Critical));
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateMinLenght(string value, string fieldCode)
        {
            var result = new List<IFieldValidationInfo>();

            if (value.Length < const_MinLenght)
            {
                result.Add(new FieldValidationInfo(fieldCode, error_MinLenght, ErrorLevel.Critical));
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateRegex(string value, string fieldCode)
        {
            var result = new List<IFieldValidationInfo>();

            var regexmatch_lowCase = Regex.IsMatch(value, Regex_Symbols_Lowcase);
            var regexmatch_upperCase = Regex.IsMatch(value, Regex_Symbols_Uppercase);
            var regexmatch_number = Regex.IsMatch(value, Regex_Symbols_Uppercase);

            if (!regexmatch_lowCase && !regexmatch_upperCase)
            {
                result.Add(new FieldValidationInfo(fieldCode, error_LowUpperCase, ErrorLevel.Critical));
            }

            if (!regexmatch_number)
            {
                result.Add(new FieldValidationInfo(fieldCode, error_NumberCase, ErrorLevel.Critical));
            }

            return result;
        }
    }
}
