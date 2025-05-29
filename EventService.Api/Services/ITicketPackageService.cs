using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;

namespace EventService.Api.Services;

public interface ITicketPackageService
{
    Task<List<TicketPackageDto>> GetByEventIdAsync(Guid eventId);
    Task<TicketPackageDto?> GetTicketPackageByIdAsync(int id);
    Task<TicketPackagesEntity> CreateAsync(RegisterTicketPackage request, Guid eventId);
    Task<bool> UpdateAsync(int id, UpdateTicketPackage request);
    Task<bool> DeleteAsync(int id);
    Task<bool> SellTicketsAsync(int packageId, int quantity);
}
