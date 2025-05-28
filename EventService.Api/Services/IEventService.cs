using EventService.Api.Contracts.Requests;
using EventService.Api.Entities;

namespace EventService.Api.Services;

public interface IEventService
{
    Task<List<EventEntity>> GetAllAsync();
    Task<EventEntity?> GetByIdAsync(Guid id);
    Task<EventEntity> CreateAsync(EventEntity entity);
    Task<bool> SaveChangesAsync();
    Task<bool> UpdateAsync(Guid id, UpdateEvent model);
    Task<bool> DeleteAsync(Guid id);
}
