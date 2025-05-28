namespace EventService.Api.Entities;

public class TicketPackagesEntity
{
    public int Id { get; set; }
    public Guid EventId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int TotalQuantity { get; set; }
    public int SoldQuantity { get; set; }

    public EventEntity Event { get; set; } = null!;
}
