using CFS.EventManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading.Tasks;

namespace CFS.EventManagement.Context
{
    public interface ICfsApiContext
    {
        DbSet<CfsEvent> Events { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Responder> Responders { get; set; }
        DbSet<Agency> Agencies { get; set; }
        DbSet<EventType> EventTypes { get; set; }
        Task SaveChangesAsync();
        int SaveChanges();
        DatabaseFacade DatabaseContext();
    }
}
