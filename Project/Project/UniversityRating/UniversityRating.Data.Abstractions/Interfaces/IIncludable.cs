using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Interfaces
{
    public interface IIncludable<TEntity, out TProperty> : ISpecification<TEntity> 
        where TEntity : Entity
    {
        
    }
}