using CFS.Common.Entities;
using CFS.EventManagement.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CFS.EventManagement.Context
{
    public class CfsApiContext : DbContext, ICfsApiContext
    {
        public DbSet<CfsEvent> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Responder> Responders { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public CfsApiContext()
        {

        }
        public CfsApiContext(DbContextOptions options) : base(options)
        {
        }
        public CfsApiContext(DbContextOptions<CfsApiContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            
        }

        public DatabaseFacade DatabaseContext()
        {
            return base.Database;
        }
        
        public async Task SaveChangesAsync()
        {
            await SaveChangesAsync(default(CancellationToken));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            #region AuditEntity
            var currentDateTime = DateTime.UtcNow;
            var added = from entry in ChangeTracker.Entries<AuditEntity>()
                        where (entry.State == EntityState.Added)
                        select entry.Entity;
            var modified = from entry in ChangeTracker.Entries<AuditEntity>()
                           where (entry.State == EntityState.Modified)
                           select entry.Entity;

            added.ToList().ForEach(m =>
            {
                m.CreatedAt = currentDateTime;
                m.UpdatedAt = currentDateTime;
            });

            modified.ToList().ForEach(m =>
            {
                m.UpdatedAt = currentDateTime;
            });
            #endregion
            return await base.SaveChangesAsync();
        }
    }
}
