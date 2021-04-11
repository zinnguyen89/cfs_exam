using System.Threading.Tasks;

namespace CFS.Common.CQRS.Command
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TResult>(ICommand<TResult> command);
    }
}
