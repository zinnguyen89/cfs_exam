using System;
using System.Linq;
using System.Linq.Expressions;

namespace CFS.Common.CQRS.Query
{
    public static class QueryExt
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int pageIndex, short itemsPerPage)
        {
            if (itemsPerPage > 0 && pageIndex > 0)
            {
                query = query.Skip((pageIndex - 1) * itemsPerPage)
                             .Take(itemsPerPage);
            }
            return query;
        }

        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int limit, int skip)
        {
            query = query.Skip(skip)
                .Take(limit);
            return query;
        }
    }
}
