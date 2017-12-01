namespace Cilesta.BusinessProcesses.Models
{
    using System.Collections.Generic;

    public class ProcessResult
    {
        public ProcessResultType Result { get; set; }

        public List<string> Errors { get; set; }

        public ProcessResult()
        {
            Result = ProcessResultType.Fail;
            Errors = new List<string>();
        }
    }
}