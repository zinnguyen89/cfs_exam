using System.Threading.Tasks;

namespace CFS.Common.CQRS.Command
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Execute(TCommand command);
    }
}
