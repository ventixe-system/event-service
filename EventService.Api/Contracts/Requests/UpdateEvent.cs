using System.ComponentModel.DataAnnotations;

namespace EventService.Api.Contracts.Requests;

public class UpdateEvent
{
    [MaxLength(100)]
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public int? CategoryId { get; set; } // From CategoryService
    public DateOnly? Date { get; set; }
    public TimeOnly? Time { get; set; }

    [MaxLength(100)]
    public string? Location { get; set; }

    [Range(0.01, 100000)]
    public decimal? StartingPrice { get; set; }
    public string? Status { get; set; }
}
