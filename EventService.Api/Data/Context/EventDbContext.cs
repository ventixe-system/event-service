using EventService.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventService.Api.Data.Context;

public class EventDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<TicketPackagesEntity> TicketPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventEntity>()
            .HasMany(e => e.TicketPackages)
            .WithOne(tp => tp.Event)
            .HasForeignKey(tp => tp.EventId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EventEntity>()
            .Property(e => e.Status)
            .HasConversion<string>();
    }
}
