using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Hubs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class NotificationsController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationsController(DigitalDialogueHubContext context, IHubContext<NotificationHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notification>>> GetAll()
        => await _context.Notifications.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Notification>> Get(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        return notification == null ? NotFound() : notification;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NotificationCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var notification = new Notification
        {
            UserId = dto.UserId,
            Message = dto.Message,
            IsRead = dto.IsRead,
            CreatedAt = DateTime.UtcNow
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        // Real-time: Pronađi connectionId-e korisnika i pošalji poruku
        var connections = NotificationHub.GetConnections(dto.UserId);
        foreach (var connectionId in connections)
        {
            await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", dto.Message);
        }

        return Ok(notification);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Notification notification)
    {
        if (id != notification.Id)
            return BadRequest();

        _context.Entry(notification).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification == null) return NotFound();

        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> NotifyAll([FromQuery] string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        return Ok("Notification sent to all.");
    }
}
