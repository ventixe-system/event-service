using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;

namespace EventService.Api.Mappings;

public static class EventMapping
{
    public static EventDto ToDto(this EventEntity entity)
    {
        return new EventDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            CategoryId = entity.CategoryId,
            Date =  DateOnly.FromDateTime(entity.Start),
            Time = TimeOnly.FromDateTime(entity.Start),
            Location = entity.Location,
            StartingPrice = entity.StartingPrice,
            Status = entity.Status.ToString(),
        };
    }
}
