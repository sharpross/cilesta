namespace Cilesta.Logging.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using Cilesta.Logging.Interfaces;

    public class EmptyLogger : ILogger
    {
        public void Error(Exception exception)
        {
            
        }

        public void Error(Exception exception, Dictionary<string, object> addtional)
        {
            
        }

        public void Init()
        {
            
        }

        public void Message(string message)
        {
            
        }

        public void Message(string message, Dictionary<string, object> addtional)
        {
            
        }

        public void Warning(Exception exception)
        {
            
        }

        public void Warning(Exception exception, Dictionary<string, object> addtional)
        {
            
        }
    }
}
