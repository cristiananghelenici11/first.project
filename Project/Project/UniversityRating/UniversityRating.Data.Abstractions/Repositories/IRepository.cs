using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        Task<TEntity> GetByIdAsync(long id);

        Task<TEntity> GetByIdAsync(long id, ISpecification<TEntity> specification);

        Task<IEnumerable<TEntity>> FindAsync(ISpecification<TEntity> specification = null);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task<int> SaveChangesAsync();
    }
}