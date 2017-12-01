namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Implimentation;

    public class StringValidator : IFieldValidator
    {
        public const string Code = "validator-string";

        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var cfg = config as StringValidatorConfig;

            var result = new List<IFieldValidationInfo>();

            if (cfg.Value == null)
            {
                var message = FormatMessage(config, Resources.Error_Empty_Field, null);
                
                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
                    
                return result;
            }

            result.AddRange(ValidateMinLenght(cfg));

            return result;
        }

        private List<IFieldValidationInfo> ValidateMinLenght(StringValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            var value = config.ToString();

            if (config.MinLenght > 0 && value.Length < config.MinLenght)
            {
                var message = FormatMessage(config, Resources.Error_String_Min, null);
                
                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
            }

            if (config.MaxLenght > 0 && value.Length > config.MaxLenght)
            {
                var message = FormatMessage(config, Resources.Error_String_Max, null);
                
                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
            }

            return result;
        }
        
        private string FormatMessage(IValidatorConfig config, string message, int? val)
        {
            var text = string.IsNullOrEmpty(config.Message) ? message : config.Message;
            var fieldName = string.IsNullOrEmpty(config.FieldCaption) ? config.FieldCode : config.FieldCaption;
            
            return val == null ? string.Format(text, fieldName) : string.Format(text, fieldName, val); 
        }
    }
}
