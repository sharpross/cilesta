namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System.Collections.Generic;
    using Castle.Windsor;
    using Core.IoC;
    using Interfaces;

    public abstract class ValidationAttribute : BaseAttribute
    {
        public ValidationAttribute()
        {
            Container = ContainerManager.Container;
        }

        protected IWindsorContainer Container { get; set; }

        public abstract List<IFieldValidationInfo> Proccess(object value, string fieldCode);
    }
}