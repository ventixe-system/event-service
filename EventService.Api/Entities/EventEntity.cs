namespace EventService.Api.Entities;

public class EventEntity
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } =null!;
    public string? ImageUrl { get; set; } = null!;
    public int CategoryId { get; set; }
    public string Status { get; set; } = null!;
    public DateTime Date {  get; set; }
    public DateTime StartTime { get; set; }
    public string? Location { get; set; }
    public decimal StartingPrice { get; set; }

    public ICollection<TicketPackagesEntity> TicketPackages { get; set; } = [];
}
