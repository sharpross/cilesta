namespace Cilesta.Scheduler.Interfaces
{
    using Castle.Windsor;
    using Cilesta.Logging.Interfaces;

    public interface IScheduler
    {
        IWindsorContainer Container { get; set; }

        ILogger Log { get; set; }

        void Init();

        void Execute(ITask task);
    }
}
