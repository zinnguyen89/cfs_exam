using CFS.Common.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFS.EventManagement.Entities
{
    [Table("Events")]
    public class CfsEvent : BaseEntity
    {
        public string EventNumber { get; set; }
        public Guid EventTypeId { get; set; }
        public DateTime EventTime { get; set; }
        public DateTime DispatchTime { get; set; }
        public Guid UserId { get; set; }
        public Guid ResponderId { get; set; }
    }
}
