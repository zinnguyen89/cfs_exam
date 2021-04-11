using System;

namespace CFS.EventManagement.Dtos
{
    public class GetEventResponse
    {
        public string AgencyId { get; set; }
        public string EventId { get; set; }
        public string EventNumber { get; set; }
        public string EventTypeCode { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public string Responder { get; set; }
    }
}
