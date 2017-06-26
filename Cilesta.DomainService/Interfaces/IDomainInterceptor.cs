namespace Cilesta.Domain.Interfaces
{
    public interface IDomainInterceptor
    {
        bool OnBefore(OperationType operation, object data);

        bool OnAfter(OperationType operation, object data);
    }
}
