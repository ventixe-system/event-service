using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventService.Api.Entities;

public class TicketPackagesEntity
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(Event))]
    public Guid EventId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(1000)]
    public string? Description { get; set; }

    [Required]
    [Range(0.01, 100000)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int TotalQuantity { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int SoldQuantity { get; set; }


    //Navigation Property
    public EventEntity Event { get; set; } = null!;
}
