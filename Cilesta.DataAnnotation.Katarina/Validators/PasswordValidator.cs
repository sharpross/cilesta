namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Implimentation;
    using Interfaces;

    public class PasswordValidator : IFieldValidator
    {
        public const string Code = "validator-password";

        private const int ConstMinLenght = 5;

        private const string RegexSymbolsLowcase = "[а-я ё a-z]*";
        private const string RegexSymbolsUppercase = "[А-Я Ё A-Z]*";
        private const string RegexNumbers = "[0-9]*";

        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            if (config.Value == null)
            {
                var text = string.IsNullOrEmpty(config.Message) ? Resources.Error_Empty_Field : config.Message;
                var fieldName = string.IsNullOrEmpty(config.FieldCaption) ? config.FieldCode : config.FieldCaption;
                var message = string.Format(text, fieldName);

                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));

                return result;
            }

            result.AddRange(ValidateEmpty(config));
            result.AddRange(ValidateMinLenght(config));
            result.AddRange(ValidateRegex(config));

            return result;
        }

        private List<IFieldValidationInfo> ValidateEmpty(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            if (string.IsNullOrEmpty(config.Value.ToString()))
            {
                var text = string.IsNullOrEmpty(config.Message) ? Resources.Error_Empty_Field : config.Message;
                var fieldName = string.IsNullOrEmpty(config.FieldCaption) ? config.FieldCode : config.FieldCaption;
                var message = string.Format(text, fieldName);

                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateMinLenght(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            if (config.Value.ToString().Length < ConstMinLenght)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, Resources.Error_Pswd_Lenght, ErrorLevel.Critical));
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateRegex(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();
            var value = config.Value.ToString();

            var regexmatchLowCase = Regex.IsMatch(value, RegexSymbolsLowcase);
            var regexmatchUpperCase = Regex.IsMatch(value, RegexSymbolsUppercase);
            var regexmatchNumber = Regex.IsMatch(value, RegexNumbers);

            if (!regexmatchLowCase && !regexmatchUpperCase)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, Resources.Error_Pswd_UpperLowCase,
                    ErrorLevel.Critical));
            }

            if (!regexmatchNumber)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, Resources.Error_Pswd_Numbers,
                    ErrorLevel.Critical));
            }

            return result;
        }
    }
}