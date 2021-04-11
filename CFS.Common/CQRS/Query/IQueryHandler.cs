using System.Threading.Tasks;

namespace CFS.Common.CQRS.Query
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Execute(TQuery query);
    }
}
