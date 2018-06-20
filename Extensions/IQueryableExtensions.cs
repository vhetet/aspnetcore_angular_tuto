using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using vega.Core.Models;
using Vega.Models;

namespace vega.Extensions
{
    public static class IQueryableExtensions<T>
    {
        public static IQueryable<T> ApplyOrdering(IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnsMap) {
            if(String.IsNullOrWhiteSpace(queryObject.SortBy) || !columnsMap.ContainsKey(queryObject.SortBy)) 
                return query;
            
            if(queryObject.IsSortAscending)
                return query.OrderBy(columnsMap[queryObject.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObject.SortBy]);
        }
    }
}