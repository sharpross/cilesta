namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Validators;

    [AttributeUsage(AttributeTargets.Property)]
    public class RangeValidatorAttribute : ValidationAttribute, IModelValidationAttribute
    {
        public const string Code = "validator-range";
        
        public int Min { get; set; }
        
        public int Max { get; set; }
        
        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = Container.Resolve<IFieldValidator>(Code);

            var config = new RangeValidatorConfig
            {
                Value = value,
                FieldCode = fieldCode,
                FieldCaption = Caption,
                Message = Message,
                Min = Min,
                Max = Max
            };

            var errors = validator.Validate(config);

            return errors;
        }
    }
}