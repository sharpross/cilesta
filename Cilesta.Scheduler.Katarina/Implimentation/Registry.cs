namespace Cilesta.Scheduler.Katarina.Implimentation
{
    using System;
    using Cilesta.Scheduler.Katarina.Interfaces;
    using FluentScheduler;

    public class CilestaRegistry : Registry, IRegistry
    {
        private void Execute(BaseTask task)
        {
            this.Schedule(task).ToRunNow();
        }

        public void Init()
        {
            
        }
    }
}
