﻿namespace Cilesta.Domain.Interfaces
{
    using System.Collections.Generic;
    using Data.Models;

    public interface IDomainService<T> where T : class, IEntity
    {
        T Get(int id);

        IList<T> GetAll();

        IList<T> GetAll(IFilter filter);

        void Save(T entity);

        void Save(IList<T> entities);

        void Delete(T entity);

        void Delete(int id);

        void Delete(IList<T> entities);
    }
}