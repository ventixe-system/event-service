using EventService.Api.Contracts.Requests;
using EventService.Api.Entities;

namespace EventService.Api.Factories;

public static class TicketPackageFactory
{
    public static TicketPackagesEntity Create(RegisterTicketPackage request, Guid eventId)
    {
        ArgumentNullException.ThrowIfNull(request);
        return new TicketPackagesEntity
        {
            EventId = eventId, // Link to the event
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            TotalQuantity = request.TotalQuantity,
            SoldQuantity = 0 // Initially no tickets sold
        };
    }

    public static void Update(TicketPackagesEntity entity, UpdateTicketPackage request)
    {
        ArgumentNullException.ThrowIfNull(entity);
        ArgumentNullException.ThrowIfNull(request);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.Price = request.Price ?? entity.Price;
        entity.TotalQuantity = request.TotalQuantity ?? entity.TotalQuantity;
        // SoldQuantity should not be updated directly, but be managed by the service logic whenever tickets are sold.
    }
}
