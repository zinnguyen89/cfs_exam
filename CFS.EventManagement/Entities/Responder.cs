using CFS.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFS.EventManagement.Entities
{
    [Table("Responders")]
    public class Responder : BaseEntity
    {
        public string Name { get; set; }
        public Guid AgencyId { get; set; }
    }
}
