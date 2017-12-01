namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Validators;

    [AttributeUsage(AttributeTargets.Property)]
    public class PasswordValidatorAttribute : ValidationAttribute, IModelValidationAttribute
    {
        public const string Code = "validator-password";

        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = Container.Resolve<IFieldValidator>(Code);

            var config = new PasswordValidatorConfig
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