using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserBadgesController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public UserBadgesController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserBadge>>> GetAll() => await _context.UserBadges.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<UserBadge>> Get(int id)
    {
        var userBadge = await _context.UserBadges.FindAsync(id);
        return userBadge == null ? NotFound() : userBadge;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] UserBadgeCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var userBadge = new UserBadge
        {
            UserId = dto.UserId,
            BadgeId = dto.BadgeId,
            EarnedAt = DateTime.UtcNow
        };

        _context.UserBadges.Add(userBadge);
        await _context.SaveChangesAsync();

        return Ok(userBadge);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserBadge userBadge)
    {
        if (id != userBadge.Id) return BadRequest();
        _context.Entry(userBadge).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userBadge = await _context.UserBadges.FindAsync(id);
        if (userBadge == null) return NotFound();
        _context.UserBadges.Remove(userBadge);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
