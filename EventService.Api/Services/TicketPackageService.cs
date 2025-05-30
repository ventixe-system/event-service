using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Data.Context;
using EventService.Api.Entities;
using EventService.Api.Factories;
using EventService.Api.Mappings;
using Microsoft.EntityFrameworkCore;

namespace EventService.Api.Services;

public class TicketPackageService : ITicketPackageService
{
    private readonly EventDbContext _context;
    public TicketPackageService(EventDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<TicketPackageDto>> GetByEventIdAsync(Guid eventId)
    {
        return await _context.TicketPackages
            .Where(tp => tp.EventId == eventId)
            .Select(tp => tp.ToDto())
            .ToListAsync();
    }
    public async Task<TicketPackageDto?> GetTicketPackageByIdAsync(int id)
    {
        var entity = await _context.TicketPackages
            .Where(tp => tp.Id == id)
            .FirstOrDefaultAsync();

        return entity?.ToDto();
    }
    public async Task<TicketPackageDto> CreateAsync(RegisterTicketPackage request, Guid eventId)
    {
        var newPackage = TicketPackageFactory.Create(request, eventId);
        await _context.TicketPackages.AddAsync(newPackage);
        await _context.SaveChangesAsync();

        return newPackage.ToDto();
    }
    public async Task<bool> UpdateAsync(Guid eventId, int id, UpdateTicketPackage request)
    {
        var existing = await _context.TicketPackages
            .Where(tp => tp.Id == id && tp.EventId == eventId)
            .FirstOrDefaultAsync();

        if (existing == null)
        {
            return false;
        }

        TicketPackageFactory.Update(existing, request);
        _context.TicketPackages.Update(existing);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(Guid eventId, int id)
    {
        var entity = await _context.TicketPackages
            .Where(tp => tp.Id == id && tp.EventId == eventId)
            .FirstOrDefaultAsync();

        if (entity == null)
        {
            return false;
        }

        _context.TicketPackages.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> SellTicketsAsync(Guid EventId, int packageId, int quantity)
    {
        var package = await _context.TicketPackages
            .Where(tp => tp.Id == packageId && tp.EventId == EventId)
            .FirstOrDefaultAsync();

        if (package == null || package.SoldQuantity + quantity > package.TotalQuantity)
        {
            return false; // Not enough tickets available
        }

        package.SoldQuantity += quantity;
        _context.TicketPackages.Update(package);
        return await _context.SaveChangesAsync() > 0;
    }
}
