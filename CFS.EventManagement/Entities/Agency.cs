using CFS.Common.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFS.EventManagement.Entities
{

    [Table("Agencies")]
    public class Agency : BaseEntity
    {
        public string Name { get; set; }
    }
}
