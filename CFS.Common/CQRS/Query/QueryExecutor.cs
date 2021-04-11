using System;
using System.Threading.Tasks;

namespace CFS.Common.CQRS.Query
{
    public class QueryExecutor : IQueryExecutor
    {
        private IServiceProvider provider { get; set; }
        public QueryExecutor(IServiceProvider provider) { this.provider = provider; }
        public async Task<TResult> Execute<TResult>(IQuery<TResult> query)
        {
            var htype = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = provider.GetService(htype);
            if (handler != null)
            {
                var raw = await handler.Execute((dynamic)query);
                return (TResult)raw;
            }
            throw new Exception(string.Format("An error has occurred while attempting to resolve a Query Handler. Query Handler of type IQueryHandler<{0},{1}> could not be resolved from the DI container.", query.GetType(), typeof(TResult)));
        }
    }
}
