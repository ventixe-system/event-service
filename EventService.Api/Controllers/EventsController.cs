using EventService.Api.Contracts.Requests;
using EventService.Api.Contracts.Responses;
using EventService.Api.Entities;
using EventService.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventService.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventManagerService eventManagerService, ITicketPackageService ticketPackageService) : ControllerBase
{
    private readonly IEventManagerService _eventManagerService = eventManagerService ?? throw new ArgumentNullException(nameof(eventManagerService));
    private readonly ITicketPackageService _ticketPackageService = ticketPackageService ?? throw new ArgumentNullException(nameof(ticketPackageService));


    //EVENT RELATED ENDPOINTS

    [HttpGet]
    public async Task<ActionResult<List<EventDto>>> GetAllEvents()
    {
        var events = await _eventManagerService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EventDto>> GetEventById(Guid id)
    {
        var eventDto = await _eventManagerService.GetEventsByIdAsync(id);
        if (eventDto == null)
        {
            return NotFound();
        }
        return Ok(eventDto);
    }

    [HttpGet("status")]
    public async Task<ActionResult<List<EventDto>>> GetEventsByStatus([FromQuery] EventStatus status)
    {
        var events = await _eventManagerService.GetEventsByStatusAsync(status);
        return Ok(events);
    }

    [HttpPost]
    public async Task<ActionResult<EventDto>> CreateEvent([FromBody] RegisterEvent request)
    {
        if (request == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {

            var createdEvent = await _eventManagerService.CreateAsync(request);

            return CreatedAtAction(nameof(GetEventById), new { id = createdEvent.Id }, createdEvent);
        }

        catch (Exception ex)
        {

            Console.WriteLine(ex.Message);
            return Problem("An error occurred while creating the event.", statusCode: 500);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] UpdateEvent request)
    {
        if (request == null)
        {
            return BadRequest("Invalid event data.");
        }

        var updated = await _eventManagerService.UpdateAsync(id, request);

        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteEvent(Guid id)
    {
        var deleted = await _eventManagerService.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }

    //TICKET PACKAGE RELATED ENDPOINTS

    [HttpPost("{eventId:guid}/ticketpackages")]
    public async Task<ActionResult<List<TicketPackageDto>>> AddTicketPackage(Guid eventId, [FromBody] RegisterTicketPackage request)
    {
        var addedPackage = await _ticketPackageService.CreateAsync(request, eventId);

        if(request == null || !ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(addedPackage);
    }

    [HttpPut("{eventId:guid}/ticketpackages/{packageId:int}")]
    public async Task<IActionResult> UpdateTicketPackage(Guid eventId, int packageId, [FromBody] UpdateTicketPackage request)
    {
        if (request == null)
        {
            return BadRequest("Invalid ticket package data.");
        }

        var updated = await _ticketPackageService.UpdateAsync(eventId, packageId, request);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{eventId:guid}/ticketpackages/{packageId:int}")]
    public async Task<IActionResult> DeleteTicketPackage(Guid eventId, int packageId)
    {
        var deleted = await _ticketPackageService.DeleteAsync(eventId, packageId);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("{eventId:guid}/ticketpackages/{packageId:int}/sell")]
    public async Task<IActionResult> SellTickets(Guid eventId, int packageId, [FromQuery] int quantity)
    {
        if (quantity <= 0)
        {
            return BadRequest("Quantity must be greater than zero.");
        }
        var sold = await _ticketPackageService.SellTicketsAsync(eventId, packageId, quantity);
        return sold ? Ok() : NotFound();
    }
}