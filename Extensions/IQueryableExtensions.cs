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

        public static IQueryable<T> ApplyPaging<T>(IQueryable<T> query, IQueryObject queryObject) {
            if(queryObject.Page <= 0)
                queryObject.Page = 1;

            if(queryObject.PageSize <= 0)
                queryObject.PageSize = 10;

            return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
        }
    }
}