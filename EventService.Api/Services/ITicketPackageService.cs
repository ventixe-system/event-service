using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;

namespace EventService.Api.Services;

public interface ITicketPackageService
{
    Task<List<TicketPackageDto>> GetByEventIdAsync(Guid eventId);
    Task<TicketPackageDto?> GetTicketPackageByIdAsync(int id);
    Task<TicketPackageDto> CreateAsync(RegisterTicketPackage request, Guid eventId);
    Task<bool> UpdateAsync(Guid EventId, int id, UpdateTicketPackage request);
    Task<bool> DeleteAsync(Guid EventId, int id);
    Task<bool> SellTicketsAsync(Guid EventId, int packageId, int quantity);
}
