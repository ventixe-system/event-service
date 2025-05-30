using EventService.Api.Contracts.Requests;
using EventService.Api.Entities;

namespace EventService.Api.Factories;

public static class EventFactory
{
    public static EventEntity Create(RegisterEvent request)
    {
        ArgumentNullException.ThrowIfNull(request);

        return new EventEntity
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            CategoryId = request.CategoryId,
            ImageUrl = request.ImageUrl,
            Status = EventStatus.Draft, // Default status on creation
            Start = request.Date.ToDateTime(request.Time), //Combine Date and Time into a DateTime
            Location = request.Location,
            StartingPrice = request.StartingPrice
        };
    }

    public static void Update(EventEntity entity, UpdateEvent request)
    {
        ArgumentNullException.ThrowIfNull(entity);
        ArgumentNullException.ThrowIfNull(request);

        entity.Title = request.Title ?? entity.Title;
        entity.Description = request.Description ?? entity.Description;
        entity.CategoryId = request.CategoryId ?? entity.CategoryId;
        entity.ImageUrl = request.ImageUrl ?? entity.ImageUrl;
        entity.Status = request.Status ?? entity.Status;

        if (request.Date.HasValue || request.Time.HasValue)
        {
            var date = request.Date ?? DateOnly.FromDateTime(entity.Start);
            var time = request.Time ?? TimeOnly.FromDateTime(entity.Start);
            entity.Start = date.ToDateTime(time);
        }
            
        entity.Location = request.Location ?? entity.Location;
        entity.StartingPrice = request.StartingPrice ?? entity.StartingPrice;
    }
}
