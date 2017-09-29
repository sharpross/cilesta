namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Cilesta.DataAnnotation.Interfaces;

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailValidationAttribute : ValidationAttribute, IModelValidationAttribute
    {
        

        public override List<IFieldValidationInfo> Proccess(object value, string fieldCode)
        {
            throw new NotImplementedException();
        }
    }
}
