namespace Cilesta.Domain.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using Castle.Windsor;
    using Data.Interfaces;
    using Data.Models;
    using Interfaces;
    using Logging.Interfaces;

    public class DomainService<T> : IDomainService<T> where T : class, IEntity
    {
        private IBridge<T> _bridge;

        private IList<IDomainInterceptor<T>> _interceptors;

        private ILogger _log;

        public IWindsorContainer Container { get; set; }

        private ILogger Log
        {
            get
            {
                if (_log == null)
                {
                    _log = Container.Resolve<ILogger>();
                }

                return _log;
            }
        }

        public IBridge<T> Bridge
        {
            get
            {
                if (_bridge == null)
                {
                    _bridge = (IBridge<T>) Container.Resolve(typeof(IBridge<>).MakeGenericType(typeof(T)));
                }

                return _bridge;
            }
        }

        public IList<IDomainInterceptor<T>> Interceptors =>
            _interceptors ?? (_interceptors = Container.ResolveAll<IDomainInterceptor<T>>());

        public void Delete(T entity)
        {
            try
            {
                if (OnBefore(OperationType.Delete, entity))
                {
                    Bridge.Delete(entity);
                }
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                //TODO: интерсептор на get?
                Bridge.Delete(id);
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }
        
        public void Delete(IList<T> entities)
        {
            try
            {
                if (OnBefore(OperationType.Delete, null, entities))
                {
                    Bridge.Delete(entities);
                }
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public T Get(int id)
        {
            try
            {
                var result = Bridge.Get(id);
                
                OnAfter(OperationType.Get, result);
                
                return result;
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                if (OnBefore(OperationType.GetAll, null))
                {
                    var result = Bridge.GetAll();
                    
                    OnAfter(OperationType.GetAll, entites: result);
                    
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public IList<T> GetAll(IFilter filter)
        {
            try
            {
                if (OnBefore(OperationType.GetAll, null))
                {
                    var criteria = filter.Parse(Bridge.Session.CreateCriteria<T>());
                    var result = Bridge.GetAll(criteria);
                    
                    OnAfter(OperationType.GetAll, entites: result);
                    
                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public void Save(T entity)
        {
            try
            {
                if (OnBefore(OperationType.Save, entity))
                {
                    Bridge.Save(entity);
                    OnAfter(OperationType.Save, entity);
                }
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public void Save(IList<T> entities)
        {
            try
            {
                if (OnBefore(OperationType.Save, entities: entities))
                {
                    Bridge.Save(entities);
                    OnAfter(OperationType.Save, null, entities);
                }
            }
            catch (Exception ex)
            {
                OnException(ex);
                throw;
            }
        }

        public bool OnBefore(OperationType operation, T entity = null, IList<T> entities = null)
        {
            foreach (var interceptor in Interceptors)
            {
                if (entity != null)
                {
                    var onBeforeResult = interceptor.OnBefore(operation, entity);

                    if (!onBeforeResult)
                    {
                        return false;
                    }
                }
                else if (entities != null)
                {
                    foreach (var record in entities)
                    {
                        var onBeforeResult = interceptor.OnBefore(operation, record);

                        if (!onBeforeResult)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public void OnAfter(OperationType operation, T entity = null, IList<T> entites = null)
        {
            foreach (var interceptor in Interceptors)
            {
                if (entity != null)
                {
                    interceptor.OnAfter(operation, entity);
                }
                else if (entites != null)
                {
                    foreach (var record in entites)
                    {
                        interceptor.OnAfter(operation, record);
                    }
                }
            }
        }

        private void OnException(Exception ex)
        {
            Log.Error(ex);
        }
    }
}