using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ReactionsController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public ReactionsController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reaction>>> GetAll() => await _context.Reactions.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Reaction>> Get(int id)
    {
        var reaction = await _context.Reactions.FindAsync(id);
        return reaction == null ? NotFound() : reaction;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] ReactionCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reaction = new Reaction
        {
            CommentId = dto.CommentId,
            UserId = dto.UserId,
            ReactionType = dto.ReactionType,
            CreatedAt = DateTime.UtcNow
        };

        _context.Reactions.Add(reaction);
        await _context.SaveChangesAsync();

        return Ok(reaction);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Reaction reaction)
    {
        if (id != reaction.Id) return BadRequest();
        _context.Entry(reaction).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var reaction = await _context.Reactions.FindAsync(id);
        if (reaction == null) return NotFound();
        _context.Reactions.Remove(reaction);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
