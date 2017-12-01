namespace Cilesta.BusinessProcesses.Katarina.Implimentation
{
    using System;
    using Castle.Windsor;
    using Data.Models;
    using DataAnnotation.Interfaces;
    using Interfaces;
    using Models;

    public abstract class BaseProcess<T, M> : IProcess<T, M>
        where T : class, IEntity
        where M : class, IValidationModel
    {
        public IWindsorContainer Container { get; set; }

        public abstract void OnBefore(M model, ProcessResult result);

        public ProcessResult Start(M model)
        {
            var result = new ProcessResult
            {
                Result = ProcessResultType.Fail
            };

            var validationResult = model.Validate();

            if (validationResult.IsValid)
            {
                try
                {
                    OnBefore(model, result);

                    InnerExecution(model, result);

                    OnAfter(model, result);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return result;
        }

        public abstract void OnAfter(M model, ProcessResult result);

        protected abstract void InnerExecution(M model, ProcessResult result);
    }
}