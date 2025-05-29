using System.ComponentModel.DataAnnotations;

namespace EventService.Api.Contracts.Requests;

public class RegisterTicketPackage
{
    [Required]
    public Guid EventId { get; set; } // From EventService

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(1000)]
    public string? Description { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int TotalQuantity { get; set; }
}
