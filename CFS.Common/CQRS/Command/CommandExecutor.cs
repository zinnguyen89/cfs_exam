using System;
using System.Threading.Tasks;

namespace CFS.Common.CQRS.Command
{
    public class CommandExecutor : ICommandExecutor
    {
        private IServiceProvider provider { get; set; }
        public CommandExecutor(IServiceProvider provider) { this.provider = provider; }
        public async Task<TResult> Execute<TResult>(ICommand<TResult> command)
        {
            var htype = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResult));
            dynamic handler = provider.GetService(htype);
            if (handler != null)
            {
                var raw = await handler.Execute((dynamic)command);
                return (TResult)raw;
            }
            throw new Exception(string.Format("An error has occurred while attempting to resolve a Command Handler. Command Handler of type ICommandHandler<{0},{1}> could not be resolved from the DI container.", command.GetType(), typeof(TResult)));
        }
    }
}
