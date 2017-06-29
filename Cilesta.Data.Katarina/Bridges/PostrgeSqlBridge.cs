namespace Cilesta.Data.Katarina.Bridges
{
    using System.Text;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Data.Katarina.Implimentation;
    using Cilesta.Data.Models;
    using FluentNHibernate.Cfg.Db;

    public class PostrgeSqlBridge<T> : BaseBridge<T> where T : class, IEntity
    {
        protected override string BuildConnectionString()
        {
            var configuration = this.Container.Resolve<IAppConfiguration>();

            var sb = new StringBuilder();
            sb.Append("Server=");
            sb.Append(configuration[Constants.Key][Constants.Host]);
            sb.Append("; Port=");
            sb.Append(configuration[Constants.Key][Constants.Port]);
            sb.Append("; Database=");
            sb.Append(configuration[Constants.Key][Constants.DataBase]);
            sb.Append("; Uid=");
            sb.Append(configuration[Constants.Key][Constants.User]);
            sb.Append("; Pwd=");
            sb.Append(configuration[Constants.Key][Constants.Password]);
            
            return sb.ToString();
        }

        protected override IPersistenceConfigurer GetDatabaseConfiguration()
        {
            var connectionString = this.ConnectionString;

            return PostgreSQLConfiguration.Standard.ConnectionString(connectionString);
        }
    }
}
