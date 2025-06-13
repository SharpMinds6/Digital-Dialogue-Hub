using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class LeaderboardsController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;

    public LeaderboardsController(DigitalDialogueHubContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaderboardDto>>> GetAll()
    {
        var leaderboards = await _context.Leaderboards
            .Select(lb => new LeaderboardDto
            {
                Id = lb.Id,
                UserId = lb.UserId,
                Points = lb.Points,
                Rank = lb.Rank
            })
            .ToListAsync();

        return Ok(leaderboards);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaderboardDto>> Get(int id)
    {
        var lb = await _context.Leaderboards.FindAsync(id);
        if (lb == null) return NotFound();

        var dto = new LeaderboardDto
        {
            Id = lb.Id,
            UserId = lb.UserId,
            Points = lb.Points,
            Rank = lb.Rank
        };

        return Ok(dto);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] LeaderboardDto dto)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
        if (!userExists)
            return BadRequest($"Korisnik sa ID {dto.UserId} ne postoji.");

        var lb = new Leaderboard
        {
            UserId = dto.UserId,
            Points = dto.Points,
            Rank = dto.Rank
        };

        _context.Leaderboards.Add(lb);
        await _context.SaveChangesAsync();

        dto.Id = lb.Id;

        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] LeaderboardDto dto)
    {
        if (id != dto.Id)
            return BadRequest();

        var lb = await _context.Leaderboards.FindAsync(id);
        if (lb == null)
            return NotFound();

        lb.UserId = dto.UserId;
        lb.Points = dto.Points;
        lb.Rank = dto.Rank;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var lb = await _context.Leaderboards.FindAsync(id);
        if (lb == null)
            return NotFound();

        _context.Leaderboards.Remove(lb);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
