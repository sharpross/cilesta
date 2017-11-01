namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    [AttributeUsage(AttributeTargets.Property)]
    public class EmailValidationAttribute : ValidationAttribute, IModelValidationAttribute
    {
        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            throw new NotImplementedException();
        }
    }
}