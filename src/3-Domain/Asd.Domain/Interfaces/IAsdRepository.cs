namespace Asd.Domain.Interfaces
{
    using Asd.Domain.Core.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IAsdRepository<T> : IDisposable where T : AsdEntity
    {
        void Add(T entity);

        T GetById(Guid id);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Remove(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}