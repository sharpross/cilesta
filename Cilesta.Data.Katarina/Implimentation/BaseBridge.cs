namespace Cilesta.Data.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Castle.Windsor;
    using Cilesta.Configuration.Interfaces;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Models;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    public abstract class BaseBridge<T> : IDisposable, IBridge<T> where T : class, IEntity
    {
        public IWindsorContainer Container { get; set; }

        protected ISession _session { get; set; }

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

        public ISession Session
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

        private bool installed;
        private bool IsInstalled
        {
            get
            {
                if (!installed)
                {
                    var configuration = this.Container.Resolve<IAppConfiguration>();
                    var value = configuration[Core.Constants.Key][Core.Constants.Installed];

                    if (!bool.TryParse(value, out installed))
                    {
                        throw new Exception("Отсуствует параметр Installed в файле конфигурации");
                    }
                }

                return installed;
            }
        }

        protected abstract string BuildConnectionString();

        protected abstract IPersistenceConfigurer GetDatabaseConfiguration();

        protected ISession GetSession()
        {
            var databaseConfiguration = this.GetDatabaseConfiguration();

            ISessionFactory sessionFactory = Fluently.Configure()
                .ExposeConfiguration(c =>
                    c.SetProperty(NHibernate.Cfg.Environment.WrapResultSets, "true")
                    .SetProperty(NHibernate.Cfg.Environment.UseQueryCache, "true")
                    .SetProperty(NHibernate.Cfg.Environment.BatchSize, "1000")
                    )
                .Database(databaseConfiguration)
                .Mappings(m =>
                {
                    this.ApplyMapping(m.FluentMappings);
                })
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }

        private void BuildSchema(Configuration config)
        {
            if (!this.IsInstalled)
            {
                var validator = new SchemaValidator(config);

                try
                {
                    validator.Validate();
                }
                catch(Exception ex)
                {
                    var updater = new SchemaUpdate(config);
                    updater.Execute(false, true);
                }
            }
        }

        private void ApplyMapping(FluentMappingsContainer fluentMappings)
        {
            var mappings = this.Container.ResolveAll<IMapping>();

            foreach (var mapping in mappings)
            {
                fluentMappings.Add(mapping.GetType());
            }
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

        public T Get(int id)
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
        
        public IList<T> GetAll(ICriteria criteria)
        {
            try
            {
                return criteria.List<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
