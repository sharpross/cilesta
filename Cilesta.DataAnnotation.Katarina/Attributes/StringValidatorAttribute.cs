namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Cilesta.DataAnnotation.Interfaces;

    public class StringValidatorAttribute : IModelValidationAttribute
    {
        public List<IFieldValidationInfo> Proccess()
        {
            return new List<IFieldValidationInfo>();
        }
    }
}
