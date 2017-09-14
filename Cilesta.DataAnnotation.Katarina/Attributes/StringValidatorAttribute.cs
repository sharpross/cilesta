﻿namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.DataAnnotation.Interfaces;
    using Cilesta.DataAnnotation.Katarina.Validators;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringValidatorAttribute : Attribute, IModelValidationAttribute
    {
        public IWindsorContainer Container { get; set; }

        public const string Code = "validator-string";

        public int MinLenght { get; set; }

        public int MaxLenght { get; set; }

        public StringValidatorAttribute()
        {
            this.MaxLenght = 0;
            this.MinLenght = 0;
        }

        public List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            var validator = this.Container.Resolve<IFieldValidator>(Code);

            var config = new StringValidatorConfig()
            {
                Value = value,
                FieldCode = fieldCode
            };

            var errors = validator.Validate(config);

            return errors;
        }
    }
}