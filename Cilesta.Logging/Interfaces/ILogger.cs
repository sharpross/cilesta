namespace Cilesta.Logging.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ILogger
    {
        void Init();

        void Message(string message);

        void Message(string message, Dictionary<string, object> addtional);

        void Error(Exception exception);
        
        void Error(Exception exception, Dictionary<string, object> addtional);

        void Warning(Exception exception);

        void Warning(Exception exception, Dictionary<string, object> addtional);
    }
}
