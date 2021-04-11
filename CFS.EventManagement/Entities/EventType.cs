using CFS.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFS.EventManagement.Entities
{
    [Table("EventTypes")]
    public class EventType : BaseEntity
    {
        public string Name { get; set; }
    }
}
