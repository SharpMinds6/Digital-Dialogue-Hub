using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CommentsController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public CommentsController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll()
    {
        var comments = await _context.Comments
            .Select(c => new CommentDto
            {
                Id = c.Id,
                Text = c.Content,
                ParentCommentId = c.ParentCommentId
            })
            .ToListAsync();

        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> Get(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        return comment == null ? NotFound() : comment;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CommentCreateDto dto)
    {
        var discussionExists = await _context.Discussions.AnyAsync(d => d.Id == dto.DiscussionId);
        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);

        if (!discussionExists || !userExists)
            return BadRequest("Discussion or User does not exist.");

        var comment = new Comment
        {
            DiscussionId = dto.DiscussionId,
            UserId = dto.UserId,
            Content = dto.Content,
            CreatedAt = dto.CreatedAt,
            ParentCommentId = dto.ParentCommentId,
            IsDeleted = dto.IsDeleted
        };

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();

        return Ok(comment);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CommentUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID in URL does not match ID in body.");

        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
            return NotFound();

        comment.DiscussionId = dto.DiscussionId;
        comment.UserId = dto.UserId;
        comment.Content = dto.Content;
        comment.CreatedAt = dto.CreatedAt;
        comment.ParentCommentId = dto.ParentCommentId;
        comment.IsDeleted = dto.IsDeleted;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePartial(int id, [FromBody] CommentPartialUpdateDto dto)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null)
            return NotFound();

        if (dto.Content != null)
            comment.Content = dto.Content;

        if (dto.IsDeleted.HasValue)
            comment.IsDeleted = dto.IsDeleted.Value;

        if (dto.ParentCommentId.HasValue)
            comment.ParentCommentId = dto.ParentCommentId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return NotFound();
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
