namespace Cilesta.Data.Katarina.Bridges
{
    using Cilesta.Data.Katarina.Implimentation;
    using Cilesta.Data.Models;
    using FluentNHibernate.Cfg.Db;

    public class MySqlBridge<T> : BaseBridge<T> where T : class, IEntity
    {
        protected override string BuildConnectionString()
        {
            var connectionString = string.Format("Server = {0}; Port = {1}; Database ={2}; Uid = {3}; Pwd = {4}");

            return connectionString;
        }

        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            var connectionString = this.ConnectionString;
            
            return MySQLConfiguration.Standard.ConnectionString(connectionString); ;
        }
    }
}
