﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventService.Api.Entities;

public class EventEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } =null!;

    public int CategoryId { get; set; } //From CategoryService

    [MaxLength(2048)]
    public string? ImageUrl { get; set; }

    [Required]
    [EnumDataType(typeof(EventStatus))]
    public EventStatus Status { get; set; }

    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Start {  get; set; }

    [MaxLength(100)]
    public string? Location { get; set; }

    [Required]
    [Range(0.01, 100000)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal StartingPrice { get; set; }

    //Navigation Property
    public ICollection<TicketPackagesEntity> TicketPackages { get; set; } = [];
}


public enum EventStatus
{
    Draft,
    Active,
    Past,
    Cancelled
}