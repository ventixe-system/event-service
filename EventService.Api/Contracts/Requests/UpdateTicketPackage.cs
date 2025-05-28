using System.ComponentModel.DataAnnotations;

namespace EventService.Api.Contracts.Requests;

public class UpdateTicketPackage
{
    [Required]
    public Guid EventId { get; set; } // From EventService

    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Range(0.01, 100000)]
    public decimal? Price { get; set; }

    [Range(1, int.MaxValue)]
    public int? TotalQuantity { get; set; }
}
