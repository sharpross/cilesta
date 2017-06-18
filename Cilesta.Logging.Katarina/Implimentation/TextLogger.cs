namespace Cilesta.Logging.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Logging.Interfaces;
    using log4net;
    using Log4NetLogger = log4net.ILog;

    public class TextLogger : ILogger, IDisposable
    {
        public IWindsorContainer Container { get; set; }

        public IAppConfiguration Configuration { get; set; }

        private static Log4NetLogger log = LogManager.GetLogger("log4netLogger");

        private bool canWrite { get; set; }

        public TextLogger()
        {
            
        }

        public void Error(Exception exception)
        {
            this.Write(exception.Message, exception, null, log4net.Core.Level.Error);
        }

        public void Error(Exception exception, Dictionary<string, object> addtional)
        {
            this.Write(exception.Message, exception, addtional, log4net.Core.Level.Error);
        }

        public void Message(string message)
        {
            this.Write(message, null, null, log4net.Core.Level.Notice);
        }

        public void Message(string message, Dictionary<string, object> addtional)
        {
            this.Write(message, null, addtional, log4net.Core.Level.Notice);
        }

        public void Warning(Exception exception)
        {
            this.Write(string.Empty, exception, null, log4net.Core.Level.Warn);
        }

        public void Warning(Exception exception, Dictionary<string, object> addtional)
        {
            this.Write(string.Empty, exception, addtional, log4net.Core.Level.Warn);
        }

        private void Write(string message, Exception exception, Dictionary<string, object> addtional, log4net.Core.Level level)
        {
            if (this.canWrite)
            {
                log.Logger.Log(typeof(TextLogger), level, string.IsNullOrEmpty(message) ? exception.Message : message, exception);
            }
        }

        public void Dispose()
        {
            this.Write("App stopped!", null, null, log4net.Core.Level.Notice);
        }

        public void Init()
        {
            log4net.Config.XmlConfigurator.Configure();

            var can = false;
            bool.TryParse(this.Configuration[Constants.Key][Constants.Enabled], out can);
            this.canWrite = can;

            this.Write("App started!", null, null, log4net.Core.Level.Notice);
        }
    }
}
