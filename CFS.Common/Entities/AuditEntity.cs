using System;

namespace CFS.Common.Entities
{
    public abstract class AuditEntity : BaseEntity
    {
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
