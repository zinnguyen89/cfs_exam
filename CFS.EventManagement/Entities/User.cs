using CFS.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFS.EventManagement.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid AgencyId { get; set; }
    }
}
