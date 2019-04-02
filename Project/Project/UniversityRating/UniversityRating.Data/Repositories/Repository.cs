using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Abstractions.Repositories;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(paramName: nameof(entity));

            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(paramName: nameof(entities));

            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(long id, ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> query = BuildQuery(specification);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification = null)
        {
            IQueryable<TEntity> query = BuildQuery(specification);

            return await query.ToListAsync();
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(paramName: nameof(entity));

            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(paramName: nameof(entities));

            _dbSet.RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected IQueryable<TEntity> BuildQuery(ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            if (specification == null) return query;

            if (specification.Includes != null && specification.Includes.Any())
            {
                query = specification.Includes.Aggregate(query,
                    (currentQuery, include) => currentQuery.Include(include));
            }

            if (specification.Predicate != null)
                query = query.Where(specification.Predicate);

            return query;
        }

        #region DisposePattern

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}