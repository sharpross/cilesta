namespace Cilesta.DataAnnotation.Katarina.Validators
{
    using System.Collections.Generic;
    using Implimentation;
    using Interfaces;

    public class RangeValidator : IFieldValidator
    {
        public const string Code = "validator-range";

        public List<IFieldValidationInfo> Validate(IValidatorConfig config)
        {
            var result = new List<IFieldValidationInfo>();

            var cfg = config as RangeValidatorConfig;

            if (cfg.Min <= 0 && cfg.Max <= 0)
            {
                return result;
            }

            if (config.Value == null)
            {
                var message = FormatMessage(config, Resources.Error_Empty_Field, null);

                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));

                return result;
            }

            var value = config.Value is int ? (int) config.Value : 0;

            if (cfg.Min > 0 && value < cfg.Min)
            {
                var message = FormatMessage(config, Resources.Error_Range_Min, cfg.Min);

                result.Add(new FieldValidationInfo(config.FieldCode, message, ErrorLevel.Critical));
            }

            if (cfg.Max > 0 && value > cfg.Max)
            {
                var message = FormatMessage(config, Resources.Error_Range_Max, cfg.Max);

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