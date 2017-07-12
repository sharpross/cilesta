namespace Cilesta.Data.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Logging.Interfaces;

    public class Migrator : IMigrator
    {
        public IWindsorContainer Container { get; set; }

        public ILogger Log { get; set; }

        public List<string> GetMigrations()
        {
            var result = new List<string>();

            var migrations = Container.ResolveAll<IMigration>();

            foreach (var migration in migrations)
            {
                if (migration.Need())
                {
                    result.Add(migration.Code);
                }
            }

            return result;
        }

        public void Migrate()
        {
            var migrations = Container.ResolveAll<IMigration>();

            foreach (var migration in migrations)
            {
                if (migration.Need())
                {
                    this.Log.Message("Start migration: " + migration.Code);

                    try
                    {
                        migration.Migrate();
                    }
                    catch (Exception ex)
                    {
                        this.Log.Error(ex);
                    }
                }
            }
        }
    }
}
