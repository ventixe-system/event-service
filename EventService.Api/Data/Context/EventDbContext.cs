using EventService.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventService.Api.Data.Context;

public class EventDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<TicketPackagesEntity> TicketPackages { get; set; }
}
