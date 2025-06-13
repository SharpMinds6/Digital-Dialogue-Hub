using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DiscussionsController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public DiscussionsController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var discussions = _context.Discussions
    .Include(d => d.User)
    .Select(d => new DiscussionDto
    {
        Id = d.Id,
        Title = d.Title,
        UserName = d.User.FullName
    })
    .ToList();

        return Ok(discussions);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Discussion>> Get(int id)
    {
        var discussion = await _context.Discussions.FindAsync(id);
        return discussion == null ? NotFound() : discussion;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] DiscussionCreateDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var discussion = new Discussion
        {
            Title = dto.Title,
            Content = dto.Content,
            UserId = dto.UserId,
            CreatedAt = DateTime.UtcNow,
            IsDeleted = dto.IsDeleted
        };

        _context.Discussions.Add(discussion);
        await _context.SaveChangesAsync();

        return Ok(discussion);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Discussion discussion)
    {
        if (id != discussion.Id) return BadRequest();
        _context.Entry(discussion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartial(int id, [FromBody] DiscussionPartialUpdateDto dto)
    {
        var discussion = await _context.Discussions.FindAsync(id);
        if (discussion == null)
            return NotFound();

        if (dto.Title != null)
            discussion.Title = dto.Title;

        if (dto.Content != null)
            discussion.Content = dto.Content;

        if (dto.IsDeleted.HasValue)
            discussion.IsDeleted = dto.IsDeleted.Value;

        await _context.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var discussion = await _context.Discussions.FindAsync(id);
        if (discussion == null) return NotFound();
        _context.Discussions.Remove(discussion);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
