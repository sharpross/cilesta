namespace Cilesta.Logging.Models
{
    using System;
    using System.Collections.Generic;

    public interface ILogRecord
    {
        string Message { get; set; }
        
        DateTimeOffset Date { get; set; }
        
        string Stacktrace { get; set; }
        
        LogLevel Level { get; set; }

        Dictionary<string, object> Additional { get; set; }

        string ToString();
    }
}