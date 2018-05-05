namespace Asd.Infra.Data.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Asd.Domain.Core.Models;
    using Asd.Domain.Interfaces;
    using Asd.Infra.Data.Context;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public abstract class AsdRepository<T> : IAsdRepository<T> where T : AsdEntity
    {
        private readonly AsdSqlContext _context;
        private readonly DbSet<T> _dbSet;

        public AsdRepository(AsdSqlContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Deleted = false;
            _dbSet.Add(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbSet.AsNoTracking()
                .Where(predicate)
                .Where(x => !x.Deleted);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(x => !x.Deleted);
        }

        public T GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));
            var entity = _dbSet.Find(id);
            return entity.Deleted ? null : entity;
        }

        public void Remove(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Deleted = true;
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Deleted = false;
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}