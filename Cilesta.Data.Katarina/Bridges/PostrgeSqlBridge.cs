namespace Cilesta.Data.Katarina.Bridges
{
    using System.Text;
    using Cilesta.Data.Katarina.Implimentation;
    using Cilesta.Data.Models;
    using FluentNHibernate.Cfg.Db;

    public class PostrgeSqlBridge<T> : BaseBridge<T> where T : class, IEntity
    {
        protected override string BuildConnectionString()
        {
            var sb = new StringBuilder();
            sb.Append("Server = ");
            sb.Append(string.Empty);
            var connectionString = string.Format("Server = {0}; Port = {1}; Database ={2}; Uid = {3}; Pwd = {4}");

            return sb.ToString();
        }

        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            var connectionString = this.ConnectionString;

            var configuration = PostgreSQLConfiguration.Standard.ConnectionString(connectionString);

            return configuration;
        }
    }
}
