namespace Cilesta.Scheduler.Katarina.Implimentation
{
    using Castle.Windsor;
    using Cilesta.Logging.Interfaces;
    using Cilesta.Scheduler.Interfaces;
    using FluentScheduler;

    public class CilestaScheduler : IScheduler
    {
        public IWindsorContainer Container { get; set; }

        private CilestaRegistry Registry { get; set; }

        public ILogger Log { get; set; }

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
            this.Log.Message("Job \"" + jobStartInfo.Name + "\" start at " + jobStartInfo.StartTime);
        }

        private void JobEnd(JobEndInfo jobStartInfo)
        {
            this.Log.Message("Job \"" + jobStartInfo.Name + "\" end at " + jobStartInfo.StartTime);
        }

        public void Execute(ITask task)
        {
            this.Registry.Execute(task);
        }
    }
}
