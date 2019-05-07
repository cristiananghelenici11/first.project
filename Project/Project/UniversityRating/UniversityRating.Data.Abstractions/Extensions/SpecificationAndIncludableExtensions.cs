using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UniversityRating.Data.Abstractions.Interfaces;
using UniversityRating.Data.Core.DomainModels;

namespace UniversityRating.Data.Abstractions.Extensions
{
    public static class SpecificationAndIncludableExtensions
    {
        private const string Separator = ".";

        public static IIncludable<TEntity, TProperty> Include<TEntity, TProperty>(
            this ISpecification<TEntity> specification, Expression<Func<TEntity, IEnumerable<TProperty>>> expression)
            where TEntity : Entity
        {
            AddIncludeInIncludes(specification, expression);

            return new Includable<TEntity, TProperty>(specification);
        }

        public static IIncludable<TEntity, TProperty> Include<TEntity, TProperty>(
            this ISpecification<TEntity> specification, Expression<Func<TEntity, TProperty>> expression)
            where TEntity : Entity
        {
            AddIncludeInIncludes(specification, expression);

            return new Includable<TEntity, TProperty>(specification);
        }

        public static IIncludable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludable<TEntity, TPreviousProperty> includable,
            Expression<Func<TPreviousProperty, TProperty>> expression, 
            params Expression<Func<TProperty, object>>[] thenIncludes)
            where TEntity : Entity
        {
            AddThenIncludeInIncludes(includable, expression, thenIncludes);

            return new Includable<TEntity, TProperty>(includable);
        }

        public static IIncludable<TEntity, TProperty> ThenInclude<TEntity, TPreviousProperty, TProperty>(
            this IIncludable<TEntity, IEnumerable<TPreviousProperty>> includable,
            Expression<Func<TPreviousProperty, TProperty>> expression,
            params Expression<Func<TProperty, object>>[] thenIncludes)
            where TEntity : Entity
        {
            AddThenIncludeInIncludes(includable, expression, thenIncludes);

            return new Includable<TEntity, TProperty>(includable);
        }

        private static void AddIncludeInIncludes<TEntity, TProperty>(ISpecification<TEntity> specification,
            Expression<Func<TEntity, TProperty>> expression)
            where TEntity : Entity
        {
            string include = string.Join(Separator, expression.ToString().Split(Separator).Skip(1));

            specification.Includes.Add(include);
        }

        private static void AddThenIncludeInIncludes<TEntity, TPreviousProperty, TProperty>(
            ISpecification<TEntity> specification, Expression<Func<TPreviousProperty, TProperty>> expression,
            params Expression<Func<TProperty, object>>[] thenIncludes)
            where TEntity : Entity
        {
            string lastInclude = specification.Includes.Last();

            specification.Includes.Remove(lastInclude);

            string include = string.Join(Separator, expression.ToString().Split(Separator).Skip(1));
            lastInclude = string.Join(Separator, lastInclude, include);

            if (thenIncludes != null)
            {
                foreach (var thenInclude in thenIncludes)
                {
                    include = string.Join(Separator, thenInclude.ToString().Split(Separator).Skip(1));

                    specification.Includes.Add(string.Join(Separator, lastInclude, include));
                }
            }
            
            specification.Includes.Add(lastInclude);
        }

        private class Includable<TEntity, TProperty> : IIncludable<TEntity, TProperty>
            where TEntity : Entity
        {
            public Expression<Func<TEntity, bool>> Predicate { get; set; }

            public List<string> Includes { get; }

            public Includable(ISpecification<TEntity> specification)
            {
                Predicate = specification.Predicate;
                Includes = specification.Includes;
            }
        }
    }
}