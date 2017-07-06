namespace Cilesta.Scheduler.Interfaces
{
    public interface IRegularTask : ISingleTask
    {
        int Minutes { get; set; }

        int Hours { get; set; }
    }
}
