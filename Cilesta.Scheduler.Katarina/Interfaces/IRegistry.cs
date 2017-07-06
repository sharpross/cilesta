namespace Cilesta.Scheduler.Katarina.Interfaces
{
    using Cilesta.Scheduler.Interfaces;

    public interface IRegistry
    {
        void Run(ITask task);
    }
}
