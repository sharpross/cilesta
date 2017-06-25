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
            this.Bridge.Delete(entity);
        }

        public void Delete(IList<T> entities)
        {
            this.Bridge.Delete(entities);
        }

        public T Get(ulong id)
        {
            return this.Bridge.Get(id);
        }

        public IList<T> GetAll()
        {
            return this.Bridge.GetAll();
        }

        public IList<T> GetAll(Expression<Func<T>> alias)
        {
            return this.Bridge.GetAll(alias);
        }

        public void Save(T entity)
        {
            this.Bridge.Save(entity);
        }

        public void Save(IList<T> entities)
        {
            this.Bridge.Save(entities);
        }
    }
}
