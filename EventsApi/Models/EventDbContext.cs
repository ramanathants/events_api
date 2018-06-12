using Microsoft.EntityFrameworkCore;

namespace EventsApi.Models
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventDetail> EventDetails { get; set; }
    }
}