using EventService.Api.Entities;

namespace EventService.Api.Contracts.Responses;

public class EventDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int CategoryId { get; set; } // From CategoryService
    public string CategoryName { get; set; } = null!; // From CategoryService
    public string? ImageUrl { get; set; }
    public string Status { get; set; } = EventStatus.Draft.ToString();
    public string? Location { get; set; }
    public decimal StartingPrice { get; set; }

    public DateOnly Date => DateOnly.FromDateTime(Start);
    public TimeOnly Time => TimeOnly.FromDateTime(Start);
    public DateTime Start { get; set; }

    public List<TicketPackageDto> TicketPackages { get; set; } = [];
}
