using EventService.Api.Entities;

namespace EventService.Api.Contracts.Responses;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; } // From CategoryService
    public string? ImageUrl { get; set; }
    public string Status { get; set; } = EventStatus.Draft.ToString();
    public string? Location { get; set; }
    public decimal StartingPrice { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; } = new TimeOnly(0, 0);

    public List<TicketPackageDto> TicketPackages { get; set; } = [];
}
