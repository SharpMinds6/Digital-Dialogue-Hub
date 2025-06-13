using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BadgesController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public BadgesController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Badge>>> GetAll() => await _context.Badges.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Badge>> Get(int id)
    {
        var badge = await _context.Badges.FindAsync(id);
        return badge == null ? NotFound() : badge;
    }

    [HttpPost]
    public async Task<ActionResult<Badge>> Create(Badge badge)
    {
        _context.Badges.Add(badge);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = badge.Id }, badge);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Badge badge)
    {
        if (id != badge.Id) return BadRequest();
        _context.Entry(badge).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var badge = await _context.Badges.FindAsync(id);
        if (badge == null) return NotFound();
        _context.Badges.Remove(badge);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
