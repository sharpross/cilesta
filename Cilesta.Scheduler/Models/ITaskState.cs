using Cilesta.Scheduler.Interfaces;

namespace Cilesta.Scheduler.Models
{
    public interface ITaskState
    {
        TaskStateType State { get; set; }

        ISingleTask Task { get; set; }
    }
}
