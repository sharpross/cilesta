namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Validators;

    [AttributeUsage(AttributeTargets.Property)]
    public class StringValidatorAttribute : ValidationAttribute, IModelValidationAttribute
    {
        public const string Code = "validator-string";

        public StringValidatorAttribute()
        {
            MaxLenght = 0;
            MinLenght = 0;
        }

        public int MinLenght { get; set; }

        public int MaxLenght { get; set; }

        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = Container.Resolve<IFieldValidator>(Code);

            var config = new StringValidatorConfig
            {
                Value = value,
                FieldCode = fieldCode,
                FieldCaption = Caption,
                Message = Message
            };

            var errors = validator.Validate(config);

            return errors;
        }
    }
}