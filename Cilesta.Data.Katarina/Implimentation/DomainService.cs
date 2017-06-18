namespace Cilesta.Data.Katarina.Implimentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Cilesta.Data.Interfaces;
    using Cilesta.Data.Katarina.Models;
    using Cilesta.Logging.Interfaces;

    public class DomainService<T> : IDomainService<T> where T : Entity
    {
        public ILogger Log { get; set; }

        private IBridge<T> _bridge { get; set; }
        
        public void Delete(T entity)
        {
            this._bridge.Delete(entity);
        }

        public void Delete(IList<T> entities)
        {
            this._bridge.Delete(entities);
        }

        public T Get(ulong id)
        {
            return this._bridge.Get(id);
        }

        public IList<T> GetAll()
        {
            return this._bridge.GetAll();
        }

        public IList<T> GetAll(Expression<Func<T>> alias)
        {
            return this._bridge.GetAll(alias);
        }

        public void Save(T entity)
        {
            this._bridge.Save(entity);
        }

        public void Save(IList<T> entities)
        {
            this._bridge.Save(entities);
        }
    }
}
