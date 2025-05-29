namespace EventService.Api.Contracts.Responses;

public class TicketPackageDto
{
    public int Id { get; set; }
    public Guid EventId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int TotalQuantity { get; set; }
    public int SoldQuantity { get; set; }
}
