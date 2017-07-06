namespace Cilesta.Scheduler.Katarina
{
    using Castle.Windsor;
    using Cilesta.Scheduler.Interfaces;
    using FluentScheduler;

    public class BaseTask : ISingleTask, IJob
    {
        public IWindsorContainer Container { get; set; }

        public void Execute()
        {
            
        }
    }
}
