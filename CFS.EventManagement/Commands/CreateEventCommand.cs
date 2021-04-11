using CFS.Common.CQRS.Command;
using CFS.EventManagement.Dtos;
using System;

namespace CFS.EventManagement.Commands
{
    public class CreateEventCommand : ICommand<CreateEventCommand.Result>
    {
        public string UserName { get; set; }
        public string EventNumber { get; set; }
        public string EventTypeCode { get; set; }
        public string EventTime { get; set; }
        public string DispatchTime { get; set; }
        public string Responder { get; set; }

        public class Result
        {
            public CreateEventResponse Data { get; set; }
        }
    }
}
