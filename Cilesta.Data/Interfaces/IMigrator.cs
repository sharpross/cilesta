namespace Cilesta.Data.Interfaces
{
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.Logging.Interfaces;

    public interface IMigrator
    {
        IWindsorContainer Container { get; set; }

        ILogger Log { get; set; }

        List<string> GetMigrations();

        void Migrate();
    }
}
