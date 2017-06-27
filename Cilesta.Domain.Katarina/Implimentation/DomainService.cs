namespace Cilesta.Domain.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Castle.Windsor;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Models;
    using Cilesta.Domain.Interfaces;
    using Cilesta.Logging.Interfaces;

    public class DomainService<T> : IDomainService<T> where T : class, IEntity
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

        private IList<IDomainInterceptor> interceptors;
        public IList<IDomainInterceptor> Interceptors
        {
            get 
            {
                if (this.interceptors == null)
                {
                    this.interceptors = this.Container.ResolveAll<IDomainInterceptor>();
                }
                return this.interceptors;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (this.OnBefore(OperationType.Delete, entity))
                {
                    this.Bridge.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public void Delete(IList<T> entities)
        {
            try
            {
                if (this.OnBefore(OperationType.Delete, entities))
                {
                    this.Bridge.Delete(entities);
                }
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public T Get(ulong id)
        {
            try
            {
                if (this.OnBefore(OperationType.Get, id))
                {
                    return this.Bridge.Get(id);
                }

                return null;
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                if (this.OnBefore(OperationType.GetAll, null))
                {
                    return this.Bridge.GetAll();
                }

                return null;
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public IList<T> GetAll(Expression<Func<T>> alias)
        {
            try
            {
                if (this.OnBefore(OperationType.GetAll, null))
                {
                    return this.Bridge.GetAll(alias);
                }

                return null;
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public void Save(T entity)
        {
            try
            {
                if (this.OnBefore(OperationType.Save, null))
                {
                    this.Bridge.Save(entity);
                }
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public void Save(IList<T> entities)
        {
            try
            {
                if (this.OnBefore(OperationType.Save, null))
                {
                    this.Bridge.Save(entities);
                }
            }
            catch (Exception ex)
            {
                this.OnException(ex);
                throw;
            }
        }

        public bool OnBefore(OperationType operation, object obj)
        {
            var result = true;
            
            foreach (var interceptor in this.Interceptors)
            {
                var onBeforeResult = interceptor.OnBefore(operation, obj);

                if (!onBeforeResult)
                {
                    return false;
                }
            }

            return result;
        }

        public void OnAfter(OperationType operation, object obj)
        {
            foreach (var interceptor in this.Interceptors)
            {
                interceptor.OnAfter(operation, obj);
            }
        }

        private void OnException(Exception ex)
        {
            this.Log.Error(ex);
        }
    }
}
