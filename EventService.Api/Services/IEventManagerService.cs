using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;

namespace EventService.Api.Services;

public interface IEventManagerService
{
    Task<List<EventDto>> GetAllEventsAsync();
    Task<EventDto?> GetEventsByIdAsync(Guid id);
    Task<EventEntity> CreateAsync(RegisterEvent request);
    Task<bool> SaveChangesAsync();
    Task<bool> UpdateAsync(Guid id, UpdateEvent model);
    Task<bool> DeleteAsync(Guid id);
}
