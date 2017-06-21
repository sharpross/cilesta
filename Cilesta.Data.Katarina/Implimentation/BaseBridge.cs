namespace Cilesta.Data.Katarina.Implimentation
{
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using NHibernate;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;
    using NHibernate.Cfg;

    public abstract class BaseBridge<T> : IDisposable, IBridge<T> where T : class, IEntity
    {
        protected ISession _session;

        private object lockObj = new object();

        protected string _connectionString;

        protected string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(this._connectionString))
                {
                    this._connectionString = this.BuildConnectionString();
                }

                return _connectionString;
            }
        }

        protected ISession Session
        {
            get
            {
                if (this._session == null)
                {
                    this._session = this.GetSession();
                }

                return this._session;
            }
        }

        protected abstract string BuildConnectionString();

        protected abstract IPersistenceConfigurer GetDatabaseConfiguration();

        protected ISession GetSession()
        {
            var databaseConfiguration = this.GetDatabaseConfiguration();

            var showSql = "false";

#if DEBUG
            showSql = "true";
#endif

            ISessionFactory sessionFactory = Fluently.Configure()
                .ExposeConfiguration(c =>
                    c.SetProperty(NHibernate.Cfg.Environment.WrapResultSets, "true")
                    .SetProperty(NHibernate.Cfg.Environment.ShowSql, showSql)
                    .SetProperty(NHibernate.Cfg.Environment.UseQueryCache, "true")
                    .SetProperty(NHibernate.Cfg.Environment.BatchSize, "1000")
                    )
                .Database(databaseConfiguration)
                .Mappings(m =>
                {
                    this.ApplyMapping(m.FluentMappings);
                })
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        private void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }

        private void ApplyMapping(FluentMappingsContainer fluentMappings)
        {
            
        }

        public void Delete(T entity)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                try
                {
                    this.Session.Delete(entity);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        public void Delete(IList<T> entities)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                try
                {
                    var entityName = typeof(T).Name;

                    this.Session.Delete(entityName, entities);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        public void Dispose()
        {
            lock (this.lockObj)
            {
                this.Session.Close();
                this.Session.Dispose();
            }

            GC.Collect();
        }

        public T Get(ulong id)
        {
            try
            {
                return (T)this.Session.Get(typeof(T).Name, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                return this.Session.CreateCriteria(typeof(T)).List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<T> GetAll(Expression<Func<T>> alias)
        {
            try
            {
                return this.Session.QueryOver(alias).List().ToList<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Save(T entity)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                try
                {
                    this.Session.SaveOrUpdate(entity);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    
                    throw ex;
                }
            }
        }

        public void Save(IList<T> entities)
        {
            using (var transaction = this.Session.BeginTransaction())
            {
                try
                {
                    foreach (var entity in entities)
                    {
                        this._session.SaveOrUpdate(entity);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    throw ex;
                }
            }
        }
    }
}
