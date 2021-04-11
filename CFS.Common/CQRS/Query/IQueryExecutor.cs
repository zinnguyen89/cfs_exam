using System.Threading.Tasks;

namespace CFS.Common.CQRS.Query
{
    public interface IQueryExecutor
    {
        Task<TResult> Execute<TResult>(IQuery<TResult> query);
    }
}
