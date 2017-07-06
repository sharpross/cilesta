namespace Cilesta.Scheduler.Katarina.Implimentation
{
    using Castle.Windsor;
    using Cilesta.Scheduler.Interfaces;
    using FluentScheduler;

    public class CilestaScheduler : IScheduler
    {
        public IWindsorContainer Container { get; set; }

        private CilestaRegistry Registry { get; set; }
        
        public void Init()
        {
            this.Registry = new CilestaRegistry();
            
            JobManager.JobStart += JobStart;
            JobManager.JobEnd += JobEnd;

            JobManager.Initialize(this.Registry);

            JobManager.Start();
        }

        private void JobStart(JobStartInfo jobStartInfo)
        {
            
        }

        private void JobEnd(JobEndInfo jobStartInfo)
        {

        }

        public void Execute(ITask task)
        {
            
        }
    }
}
