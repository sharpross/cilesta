namespace Cilesta.Data.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Models;
    using Cilesta.Logging.Interfaces;

    public class DataService<T> : IDataService<T> where T : class, IEntity
    {
        public IWindsorContainer Container { get; set; }

        private ILogger log;
        public ILogger Log 
        { 
            get 
            {
                if (this.log == null)
                {
                    this.log = this.Container.Resolve<ILogger>();
                }

                return this.log;
            }
        }

        private IBridge<T> bridge;
        public IBridge<T> Bridge 
        {
            get
            {
                if (this.bridge == null)
                {
                    this.bridge = (IBridge<T>)this.Container.Resolve(typeof(IBridge<>).MakeGenericType(typeof(T)));
                }

                return this.bridge;
            }
        }
        
        public void Delete(T entity)
        {
            try
            {
                this.Bridge.Delete(entity);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public void Delete(IList<T> entities)
        {
            try
            {
                this.Bridge.Delete(entities);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public T Get(ulong id)
        {
            try
            {
                return this.Bridge.Get(id);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                return this.Bridge.GetAll();
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public IList<T> GetAll(Expression<Func<T>> alias)
        {
            try
            {
                return this.Bridge.GetAll(alias);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public void Save(T entity)
        {
            try
            {
                this.Bridge.Save(entity);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public void Save(IList<T> entities)
        {
            try
            {
                this.Bridge.Save(entities);
            }
            catch (Exception ex)
            {
                this.Log.Error(ex);
                throw;
            }
        }

        public bool OnBefore(OperationType operation, object obj)
        {
            var result = true;



            return result;
        }
    }
}
