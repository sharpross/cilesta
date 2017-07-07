namespace Cilesta.Scheduler.Katarina.Implimentation
{
    using Cilesta.Scheduler.Interfaces;
    using Cilesta.Scheduler.Katarina.Interfaces;
    using FluentScheduler;

    public class CilestaRegistry : Registry, IRegistry
    {
        public void Execute(ITask task)
        {
            if(task is SingleTask)
            {
                this.Schedule(task as IJob).ToRunNow();
            }

            if (task is RegularTask)
            {
                this.Schedule(task as IJob)..ToRunNow();
            }
        }

        public void Init()
        {
            
        }
    }
}
