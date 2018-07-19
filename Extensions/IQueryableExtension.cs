using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ASP_Angular.Core.Models;

namespace ASP_Angular.Extensions
{
    public static class IQueryableExtension
    {
          public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query,IQueryObject queryObj, Dictionary<string,Expression<Func<T, object>>> columnMap) {
            if( String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnMap.ContainsKey(queryObj.SortBy))
             return query;
            if (queryObj.IsSortByAccending)
                return query.OrderBy(columnMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnMap[queryObj.SortBy]);
        }
    }
}