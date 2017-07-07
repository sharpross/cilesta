namespace Cilesta.Scheduler.Katarina.Interfaces
{
    using Cilesta.Scheduler.Interfaces;

    public interface IRegistry
    {
        void Execute(ITask task);
    }
}
