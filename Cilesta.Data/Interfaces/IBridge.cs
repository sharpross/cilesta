namespace Cilesta.Data.Interfaces
{
    using System.Collections.Generic;
    using Cilesta.Data.Models;
    using NHibernate;

    public interface IBridge<T> where T : class, IEntity
    {
        ISession Session { get; }

        T Get(int id);

        IList<T> GetAll();

        IList<T> GetAll(ICriteria criteria);
        
        void Save(T entity);

        void Save(IList<T> entities);

        void Delete(T entity);

        void Delete(int id);

        void Delete(IList<T> entities);
    }
}
