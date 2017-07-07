namespace Cilesta.Scheduler.Katarina.Implimentation
{
    using Castle.Windsor;
    using Cilesta.Scheduler.Interfaces;

    public abstract class SingleTask : ISingleTask
    {
        public IWindsorContainer Container { get; set; }

        public SingleTask(IWindsorContainer container)
        {
            this.Container = container;
        }

        public abstract void Execute();
    }
}
