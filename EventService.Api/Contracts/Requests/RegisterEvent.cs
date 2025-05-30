using System.ComponentModel.DataAnnotations;

namespace EventService.Api.Contracts.Requests;

public class RegisterEvent
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int CategoryId { get; set; }// From CategoryService

    [Required]
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; } = new TimeOnly(0, 0);

    [MaxLength(100)]
    public string? Location { get; set; } = "To be announced";

    [Required]
    [Range(0.01, 100000)]
    public decimal StartingPrice { get; set; }
}
