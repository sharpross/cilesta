namespace Cilesta.Scheduler.Interfaces
{
    using Castle.Windsor;

    public interface ITask
    {
        IWindsorContainer Container { get; set; }

        void Execute();
    }
}
