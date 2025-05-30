using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Data.Context;
using EventService.Api.Entities;
using EventService.Api.Factories;
using EventService.Api.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EventService.Api.Services;

public class EventManagerService : IEventManagerService
{
    private readonly EventDbContext _context;

    public EventManagerService(EventDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<EventDto>> GetAllEventsAsync()
    {
        return await _context.Events
            .Include(e => e.TicketPackages)
            .Select(e => e.ToDto())
            .ToListAsync();
    }

    public async Task<EventDto?> GetEventsByIdAsync(Guid id)
    {
        var entity = await _context.Events
            .Include(e => e.TicketPackages)
            .FirstOrDefaultAsync(e => e.Id == id);
        return entity?.ToDto();
    }

    public async Task<List<EventDto>>GetEventsByStatusAsync(EventStatus status)
    {
        var filteredEvents = await _context.Events
            .Include(e => e.TicketPackages)
            .Where (e => e.Status == status)
            .ToListAsync();

        return filteredEvents.Select(e => e.ToDto()).ToList();
    }

    public async Task<EventDto> CreateAsync(RegisterEvent request)
    {
        var newEvent = EventFactory.Create(request);
        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        return newEvent.ToDto();
    }

    public async Task<bool> SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateEvent request)
    {
        var existing = await _context.Events.FindAsync(id);

        if (existing == null)
        {
            return false;
        }

        EventFactory.Update(existing, request);
        return await SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _context.Events.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _context.Events.Remove(entity);
        return await SaveChangesAsync();
    }
}
