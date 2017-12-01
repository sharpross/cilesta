namespace Cilesta.BusinessProcesses.Interfaces
{
    using Castle.Windsor;
    using Data.Models;
    using DataAnnotation.Interfaces;
    using Models;

    public interface IProcess<T, M>
        where T : class, IEntity
        where M : class, IValidationModel
    {
        IWindsorContainer Container { get; set; }

        void OnBefore(M model, ProcessResult result);

        ProcessResult Start(M model);

        void OnAfter(M model, ProcessResult result);
    }
}