namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Validators;

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidationAttribute : ValidationAttribute, IModelValidationAttribute
    {
        public const string Code = "validator-email";

        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = Container.Resolve<IFieldValidator>(Code);

            var config = new EmailValidatorConfig
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