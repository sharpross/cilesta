namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Validators;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PasswordValidatorAttribute : Attribute, IModelValidationAttribute
    {
        public IWindsorContainer Container { get; set; }

        public const string Code = "validator-password";
        
        public List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = this.Container.Resolve<IFieldValidator>(Code);

            var config = new PasswordValidatorConfig()
            {
                Value = value,
                FieldCode = fieldCode
            };

            var errors = validator.Validate(config);

            return errors;
        }
    }
}
