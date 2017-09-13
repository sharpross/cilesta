namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class StringValidator : IFieldValidator
    {
        public const string Code = "validator-string";

        private const string error_Empty = "Поле не может быть пустым.";
        private const string error_MinLenght = "Минимальная длина поля {0} символов.";
        private const string error_MaxLenght = "Максимальная длина поля {0} символов.";

        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var cfg = config as StringValidatorConfig;

            var result = new List<IFieldValidationInfo>();

            if (cfg.Value == null)
            {
                
            }

            var value = cfg.Value.ToString();

            if (string.IsNullOrEmpty(value))
            {
                
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateEmpty(StringValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            if (string.IsNullOrEmpty(config.Value.ToString()))
            {
                result.Add(new FieldValidationInfo(config.FieldCode, error_Empty, ErrorLevel.Critical));
            }

            return result;
        }

        private List<IFieldValidationInfo> ValidateMinLenght(StringValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            var value = config.ToString();

            if (config.MinLenght > 0 && value.Length < config.MinLenght)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, error_MinLenght, ErrorLevel.Critical));
            }

            if (config.MaxLenght > 0 && value.Length > config.MaxLenght)
            {
                result.Add(new FieldValidationInfo(config.FieldCode, error_MinLenght, ErrorLevel.Critical));
            }

            return result;
        }
    }
}
