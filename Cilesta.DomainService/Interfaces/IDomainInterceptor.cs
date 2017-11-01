namespace Cilesta.Domain.Interfaces
{
    using Castle.Windsor;

    public interface IDomainInterceptor<T>
    {
        IWindsorContainer Container { get; set; }

        bool OnBefore(OperationType operation, T entity);

        void OnAfter(OperationType operation, T entity);
    }
}