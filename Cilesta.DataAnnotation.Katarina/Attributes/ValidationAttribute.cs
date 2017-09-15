namespace Cilesta.DataAnnotation.Katarina.Attributes
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.Core.IoC;
    using Cilesta.DataAnnotation.Interfaces;

    public abstract class ValidationAttribute : Attribute
    {
        protected IWindsorContainer Container { get; set; }

        public ValidationAttribute()
        {
            this.Container = ContainerManager.Container;
        }

        public abstract List<IFieldValidationInfo> Proccess(object value, string fieldCode);
    }
}
