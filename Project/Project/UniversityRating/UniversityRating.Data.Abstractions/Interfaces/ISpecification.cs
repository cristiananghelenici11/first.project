using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Interfaces
{
    public interface ISpecification<TEntity> where TEntity : Entity
    {
        Expression<Func<TEntity, bool>> Predicate { get; set; }

        List<string> Includes { get; }
    }
}