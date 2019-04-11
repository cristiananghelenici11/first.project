using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Repositories
{
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : Entity
    {
        public Expression<Func<TEntity, bool>> Predicate { get; set; }

        public List<string> Includes { get; } = new List<string>();
    }
}