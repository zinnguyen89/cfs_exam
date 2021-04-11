using System;

namespace CFS.EventManagement.Dtos
{
    public class CreateEventResponse
    {
        public Guid AgencyId { get; set; }
        public Guid EventId { get; set; }
        public string EventNumber { get; set; }
        public string EventTypeCode { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public string Responder { get; set; }
    }
}
