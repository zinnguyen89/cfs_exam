using CFS.Common.Controllers;
using CFS.Common.CQRS.Command;
using CFS.Common.CQRS.Query;
using CFS.EventManagement.Commands;
using CFS.EventManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CFS.EventManagement.Api.Controllers
{
    public class EventsController : BaseController
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public EventsController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [Route("")]
        [HttpPost()]
        [ProducesResponseType(typeof(CreateEventCommand.Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<CreateEventCommand.Result> CreateEvent(CreateEventCommand command)
        {
            return await _commandExecutor.Execute(command);
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(GetEventsByFilterQuery.Result), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<GetEventsByFilterQuery.Result> GetEvents([FromQuery] GetEventsByFilterQuery query)
        {
            return await _queryExecutor.Execute(query);
        }
    }
}
