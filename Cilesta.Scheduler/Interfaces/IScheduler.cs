namespace Cilesta.Scheduler.Interfaces
{
    using Castle.Windsor;

    public interface IScheduler
    {
        IWindsorContainer Container { get; set; }

        void Init();

        void Execute(ITask task);
    }
}
