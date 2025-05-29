using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;

namespace EventService.Api.Mappings;

public static class TicketPackageMapping
{
    public static TicketPackageDto ToDto(this TicketPackagesEntity entity)
    {
        return new TicketPackageDto
        {
            Id = entity.Id,
            EventId = entity.EventId,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            TotalQuantity = entity.TotalQuantity,
            SoldQuantity = entity.SoldQuantity
        };
    }
}
