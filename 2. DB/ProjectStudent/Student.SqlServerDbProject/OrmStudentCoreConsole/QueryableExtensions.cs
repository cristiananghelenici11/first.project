﻿using System.Linq;

namespace OrmStudentCoreConsole
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, 	int page = 1, int pageSize = 10)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }

    }
}